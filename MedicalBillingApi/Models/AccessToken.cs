﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalBillingApi.Models
{
    public sealed class AccessToken
    {
        public string AuthToken { get; }
        public int ExpiresIn { get; }

        public AccessToken(string token, int expiresIn)
        {
            AuthToken = token;
            ExpiresIn = expiresIn;
        }
    }
}
