// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityServer4;

namespace IdentityServerHost.Quickstart.UI
{
    public class AppUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "13115 Sanctuary Cove DR",
                    locality = "Temple Terrace",
                    postal_code = 33637,
                    country = "USA"
                };
                
                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "818727",
                        Username = "ajay",
                        Password = "a1",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Ajay Kumar"),
                            new Claim(JwtClaimTypes.GivenName, "Ajay"),
                            new Claim(JwtClaimTypes.FamilyName, "Kumar"),
                            new Claim(JwtClaimTypes.Email, "ajay.kumar8@capgemini.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://ajay.io"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "admin")
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "88421113",
                        Username = "neha",
                        Password = "n1",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Neha Kumari"),
                            new Claim(JwtClaimTypes.GivenName, "Neha"),
                            new Claim(JwtClaimTypes.FamilyName, "Kumari"),
                            new Claim(JwtClaimTypes.Email, "NehaKumari@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://nehakumari.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "user")
                        }
                    }
                };
            }
        }
    }
}