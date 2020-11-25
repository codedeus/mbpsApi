using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalBillingApi.Entities;
using MedicalBillingApi.DTO;
using Microsoft.AspNetCore.Authorization;

namespace MedicalBillingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoiceController : BaseController
    {
        private readonly AppDataContext _context;

        public InvoiceController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Invoices.Where(i => i.HasPaid == false).Select(s => new { s.Id, s.Number }).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetInvoiceDetails(int id)
        {
            return Ok( await _context.Invoices.Where(s => s.Id == id && s.HasPaid == false).Include(s => s.InvoiceItems).Select(s => new
            {
                s.Id,
                s.CustomerAddress,
                s.CustomerDateOfBirth,
                s.CustomerGender,
                s.CustomerName,
                s.Number,
                Services = s.InvoiceItems.Select(s => new { s.Id, s.Quantity, Price = s.ItemPrice, s.Item.Name, s.Item.BrandName }).ToList()
            }).FirstOrDefaultAsync());
        }

        // POST: api/Invoice
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult> PostInvoice(InvoiceRequestDTO payload)
        {
            var invoice = new Invoice
            {
                BillerId = GetUserId(),
                CustomerDateOfBirth = payload.CustomerDateOfBirth,
                InvoiceDate = DateTime.Now,
                CustomerGender = payload.CustomerGender,
                CustomerId = payload.CustomerId,
                CustomerName = $"{payload.CustomerLastName} {payload.CustomerFirstName}",
                HasPaid = false,
                CustomerAddress = payload.CustomerAddress,
                IsActive = true,
                Number = ""
            };
            var today = DateTime.Now;
            Customer customer = null;
            foreach (var item in payload.Services)
            {
                var invoiceItem = new InvoiceItem
                {
                    HasPaid = false,
                    IsDeleted = false,
                    ItemId = item.Id,
                    ItemPrice = item.Price,
                    Quantity = item.Quantity
                };

                invoice.AddInvoiceItem(invoiceItem);
            }
           
            if (payload.SaveCustomer)
            {
                customer = new Customer
                {
                    DateOfBirth = payload.CustomerDateOfBirth,
                    Created = today,
                    CreatedById = GetUserId(),
                    FirstName = payload.CustomerFirstName,
                    Gender = payload.CustomerGender,
                    IsActive = true,
                    LastName = payload.CustomerLastName,
                    MaritalState = null,
                    Number = "",
                    ResidentialAddress = null
                };
                invoice.Customer = customer;
            }

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            invoice.Number = $"{payload.Prefix}{invoice.Id:D6}";
            if (customer != null)
            {
                customer.Number = $"CST{customer.Id:D6}";
            }

            await _context.SaveChangesAsync();
            return Ok(new { InvoiceNumber = invoice.Number, CustomerNumber = customer?.Number });
        }

        [HttpPost("{invoiceId}/pay")]
        public async Task<ActionResult> PayInvoice(int invoiceId, [FromBody] PaymentRequest request)
        {
            var today = DateTime.Now;
            var invoice = _context.Invoices.Where(i => i.HasPaid == false && i.Id == invoiceId).Include(s => s.InvoiceItems).FirstOrDefault();
            if (invoice!=null)
            {
                var receipt = new Receipt
                {
                    PaymentDate = today,
                    AmountPaid = invoice.InvoiceItems.Sum(s=>s.ItemPrice * s.Quantity),
                    CashierId = GetUserId(),
                    Number = "",
                    PaymentMode = request.PaymentMode
                };
                invoice.HasPaid = true;
                foreach (var item in invoice.InvoiceItems)
                {
                    item.HasPaid = true;
                    item.Receipt = receipt;
                }

                _context.Receipts.Add(receipt);
                await _context.SaveChangesAsync();
                receipt.Number = $"RT{receipt.Id:D6}";
                await _context.SaveChangesAsync();
                return Ok(receipt.Number);
            }
            return BadRequest("invalid invoice");
        }
    }
}
