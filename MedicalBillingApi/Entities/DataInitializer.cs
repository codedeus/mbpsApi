using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalBillingApi.Entities
{
    public class DataInitializer
    {
        public static class UserAndRoleDataInitializer
        {
            public static void SeedData(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppDataContext dbContext)
            {
                SeedRoles(roleManager);
                SeedUsers(userManager, dbContext);
            }

            private static void SeedUsers(UserManager<AppUser> userManager, AppDataContext dbContext)
            {

                if (!dbContext.Departments.Any())
                {
                    Department pharmacy = new Department {  Name = "Pharmacy" };
                    Department lab = new Department { Name = "Laboratory" };
                    Department radiology = new Department {   Name = "Radiology" };
                    Department account = new Department{Name = "Accounts"};
                    Department admin = new Department { Name = "Admin" };

                    dbContext.Add(admin);
                    dbContext.Add(radiology);
                    dbContext.Add(account);
                    dbContext.Add(lab);
                    dbContext.Add(pharmacy);

                    var labServices = new List<Service>
                    {
                        new Service{BrandName = null,Department = lab,IsActive = true,Name = "Full Blood Count",Price = 750},
                        new Service{BrandName = null,Department = lab,IsActive = true,Name = "ASCITIC FLUID ANALYSIS",Price = 50},
                        new Service{BrandName = null,Department = lab,IsActive = true,Name = "BLOOD CULTURE",Price = 100},
                        new Service{BrandName = null,Department = lab,IsActive = true,Name = "EAR SWAB MCS",Price = 150},
                        new Service{BrandName = null,Department = lab,IsActive = true,Name = "Semen Analysis",Price = 200},
                        new Service{BrandName = null,Department = lab,IsActive = true,Name = "SERUM ALBUMIN",Price = 250},
                        new Service{BrandName = null,Department = lab,IsActive = true,Name = "SPOT URINE CREATININE",Price = 300},
                        new Service{BrandName = null,Department = lab,IsActive = true,Name = "TOTAL TRIIODOTHYRONINE T3",Price = 350},
                        new Service{BrandName = null,Department = lab,IsActive = true,Name = "URINE PROTEIN/CREATININE",Price = 400},
                        new Service{BrandName = null,Department = lab,IsActive = true,Name = "URINE MICROSCOPY",Price = 450},
                        new Service{BrandName = null,Department = lab,IsActive = true,Name = "SCREENING OF DONOR BLOOD",Price = 500},
                        new Service{BrandName = null,Department = lab,IsActive = true,Name = "Platelate Count",Price = 550},
                        new Service{BrandName = null,Department = lab,IsActive = true,Name = "Rapid screen HIV",Price = 600},
                        new Service{BrandName = null,Department = lab,IsActive = true,Name = "Malaria Parasite",Price = 650},
                        new Service{BrandName = null,Department = lab,IsActive = true,Name = "HB Genotype(HPLC)",Price = 700}
                    };

                    var radServices = new List<Service>
                    {
                        new Service{BrandName = null,Department = radiology,IsActive = true,Name = "Scanogram",Price = 750},
                        new Service{BrandName = null,Department = radiology,IsActive = true,Name = "FULL C.T SCAN",Price = 50},
                        new Service{BrandName = null,Department = radiology,IsActive = true,Name = "CT NECK ONLY",Price = 100},
                        new Service{BrandName = null,Department = radiology,IsActive = true,Name = "ABDOMEN AND PELVIS",Price = 150},
                        new Service{BrandName = null,Department = radiology,IsActive = true,Name = "ABDOMEN ERECT/SUPINE",Price = 200},
                        new Service{BrandName = null,Department = radiology,IsActive = true,Name = "BOTH HANDS",Price = 250},
                        new Service{BrandName = null,Department = radiology,IsActive = true,Name = "BOTH HUMERUS AP/LAT",Price = 300},
                        new Service{BrandName = null,Department = radiology,IsActive = true,Name = "BOTH WRIST",Price = 350},
                        new Service{BrandName = null,Department = radiology,IsActive = true,Name = "BRAIN CT SCAN",Price = 400},
                        new Service{BrandName = null,Department = radiology,IsActive = true,Name = "BREAST SCAN",Price = 450},
                        new Service{BrandName = null,Department = radiology,IsActive = true,Name = "Cervical Spine",Price = 500},
                        new Service{BrandName = null,Department = radiology,IsActive = true,Name = "Chemotherapy ",Price = 550},
                        new Service{BrandName = null,Department = radiology,IsActive = true,Name = "COLONGRAPHY",Price = 600},
                        new Service{BrandName = null,Department = radiology,IsActive = true,Name = "COMBINED MCU+RCU",Price = 650},
                        new Service{BrandName = null,Department = radiology,IsActive = true,Name = "FEMUR AP/LAT ",Price = 700}
                    };

                    var drugs = new List<Service>
                    {
                        new Service{BrandName = "AVENTIS", Department = pharmacy,IsActive = true,Name = " GLIBENCLAMIDE TAB",Price = 750},
                        new Service{BrandName = "ACTAVIS & TEVA", Department = pharmacy,IsActive = true,Name = " DIPYRIDAMOLE TAB ",Price = 50},
                        new Service{BrandName = "COXAL", Department = pharmacy,IsActive = true,Name = "LATANOPROST + TIMOLOL EYE DROP",Price = 100},
                        new Service{BrandName = "PENINE", Department = pharmacy,IsActive = true,Name = "PENINE SUCTION CATHETER SIZE 8",Price = 150},
                        new Service{BrandName = "UNIDEX", Department = pharmacy,IsActive = true,Name = "10% DEXTROSE WATER",Price = 200},
                        new Service{BrandName = "UNIMANN-10", Department = pharmacy,IsActive = true,Name = "10% MANNITOL 500ML",Price = 250},
                        new Service{BrandName = "CATHETER", Department = pharmacy,IsActive = true,Name = "2-WAY CATHETER 16FR",Price = 300},
                        new Service{BrandName = "BIOFLEX", Department = pharmacy,IsActive = true,Name = "4.3% DEXTROSE SALINE",Price = 350},
                        new Service{BrandName = null,Department = pharmacy,IsActive = true,Name = "5% SULPHUR OINTMENT",Price = 400},
                        new Service{BrandName = "VOATHERM", Department = pharmacy,IsActive = true,Name = "A-B AREETHER",Price = 450},
                        new Service{BrandName = "DELEJECT", Department = pharmacy,IsActive = true,Name = "5ML SYRINGE",Price = 500},
                        new Service{BrandName = "ACLOTABS", Department = pharmacy,IsActive = true,Name = "ACECLOFENAC",Price = 550},
                        new Service{BrandName = "EMPRIN-75", Department = pharmacy,IsActive = true,Name = "ACETYLSALICYLIC ACID TAB",Price = 600},
                        new Service{BrandName = null, Department = pharmacy,IsActive = true,Name = "ACID CONCERNTRATE 10L",Price = 650},
                        new Service{BrandName = "AXEITOL", Department = pharmacy,IsActive = true,Name = "ALBENDAZOLE TAB ",Price = 700}
                    };

                    dbContext.Services.AddRange(labServices);
                    dbContext.Services.AddRange(drugs);
                    dbContext.Services.AddRange(radServices);

                    dbContext.SaveChanges();

                    AppUser pharmacyUser = new AppUser
                    {
                        UserName = "pharmacist@mail.com",
                        Email = "pharmacist@mail.com",
                        FirstName = "John",
                        LastName = "Doe",
                        Department = pharmacy,
                        Role = "Pharmacist"
                    };

                    IdentityResult pharmacyUserresult = userManager.CreateAsync(pharmacyUser, "password1").Result;

                    if (pharmacyUserresult.Succeeded)
                    {
                        userManager.AddToRoleAsync(pharmacyUser, "Pharmacist").Wait();
                    }

                    AppUser cashierUser = new AppUser
                    {
                        UserName = "cashier@mail.com",
                        Email = "cashier@mail.com",
                        FirstName = "Alex",
                        LastName = "Calingasan",
                        DepartmentId = account.Id,
                        Role = "Cashier"
                    };

                    IdentityResult cashierUserResult = userManager.CreateAsync(cashierUser, "password2").Result;

                    if (cashierUserResult.Succeeded)
                    {
                        userManager.AddToRoleAsync(cashierUser, "Cashier").Wait();
                    }

                    AppUser labUser = new AppUser
                    {
                        UserName = "labbiler@mail.com",
                        Email = "labbiler@mail.com",
                        FirstName = "David",
                        LastName = "Stone",
                        DepartmentId = lab.Id,
                        Role = "Lab Biller"
                    };

                    IdentityResult labBillerresult = userManager.CreateAsync(labUser, "password3").Result;

                    if (labBillerresult.Succeeded)
                    {
                        userManager.AddToRoleAsync(labUser, "Lab Biller").Wait();
                    }

                    AppUser radiologyUser = new AppUser
                    {
                        UserName = "radiologybiler@mail.com",
                        Email = "radiologybiler@mail.com",
                        FirstName = "Steve",
                        LastName = "Austine",
                        Department = radiology,
                        Role = "Radiology Biller"
                    };

                    IdentityResult radiologyUserResult = userManager.CreateAsync(radiologyUser, "password4").Result;

                    if (radiologyUserResult.Succeeded)
                    {
                        userManager.AddToRoleAsync(radiologyUser, "Radiology Biller").Wait();
                    }

                    AppUser adminUser = new AppUser
                    {
                        UserName = "admin@mail.com",
                        Email = "admin@mail.com",
                        FirstName = "Kelvin",
                        LastName = "Bryant",
                        DepartmentId = admin.Id,
                        Role = "Admin"
                    };

                    IdentityResult adminresult = userManager.CreateAsync(adminUser, "password5").Result;

                    if (adminresult.Succeeded)
                    {
                        userManager.AddToRoleAsync(adminUser, "Admin").Wait();
                    }
                }
            
            }

            private static void SeedRoles(RoleManager<IdentityRole> roleManager)
            {
                if (!roleManager.RoleExistsAsync("Pharmacist").Result)
                {
                    IdentityRole role = new IdentityRole
                    {
                        Name = "Pharmacist"
                    };
                    IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
                }

                if (!roleManager.RoleExistsAsync("Lab Biller").Result)
                {
                    IdentityRole role = new IdentityRole
                    {
                        Name = "Lab Biller"
                    };
                    IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
                }

                if (!roleManager.RoleExistsAsync("Radiology Biller").Result)
                {
                    IdentityRole role = new IdentityRole
                    {
                        Name = "Radiology Biller"
                    };
                    IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
                }

                if (!roleManager.RoleExistsAsync("Cashier").Result)
                {
                    IdentityRole role = new IdentityRole
                    {
                        Name = "Cashier"
                    };
                    IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
                }

                if (!roleManager.RoleExistsAsync("Admin").Result)
                {
                    IdentityRole role = new IdentityRole
                    {
                        Name = "Admin"
                    };
                    IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
                }
            }


        }
    }
}
