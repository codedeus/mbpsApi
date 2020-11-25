﻿using MedicalBillingApi.Interfaces;
using System;
using System.Security.Cryptography;


namespace MedicalBillingApi.Auth
{
    public sealed class TokenFactory : ITokenFactory
    {
        public string GenerateToken(int size=32)
        {
            var randomNumber = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
