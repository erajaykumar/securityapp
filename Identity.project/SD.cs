using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using Duende.IdentityServer;
using IdentityModel;
using System.Security.Claims;
using Microsoft.OpenApi.Writers;

namespace Identity.project
{
    public static class SD
    {
        public const string Admin = "admin";
        public const string Customer = "user";

        public static IEnumerable<Client> Clients =>
           new Client[]
           {
                   new Client
             {                
                 ClientId = "ruleapi",
                 ClientName = "rule api",
                 ClientSecrets = { new Secret("secret".Sha256()) },

                 AllowedGrantTypes = GrantTypes.ClientCredentials,
                
                 AllowedScopes =
                 {
                           "testapi",
                 },

             },

                new Client
             {
                 RequirePkce = false,
                 ClientId = "ruleEngine",
                 ClientName = "rule engine",
                 ClientSecrets = { new Secret("test".Sha256()) },

                 AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,              

                 AllowedScopes =
                 {"ruleAPI",
                     IdentityServerConstants.StandardScopes.OpenId,
                     IdentityServerConstants.StandardScopes.Profile,
                     IdentityServerConstants.StandardScopes.Email,
                 },
                 RedirectUris = { "https://localhost:7004/signin-oidc" },
                 PostLogoutRedirectUris =
                   { "https://localhost:7004/signout-callback-oidc" },
                 

             }
           };
        public static IEnumerable<ApiScope> apiScopes =>
            new ApiScope[]
            {
                new ApiScope("ruleAPI","rule API"),
                new ApiScope(name:"read", displayName:"Read your data."),
                new ApiScope(name:"write", displayName:"Write your data."),
                new ApiScope(name:"delete",displayName:"Delete your data")
            };
        public static IEnumerable<ApiResource> apiResources =>
            new ApiResource[]
            {
                //new ApiResource("myapi","my test api")
                
            };
        public static IEnumerable<IdentityResource> identityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()                
                //new IdentityResource("roles", "User role", new List<string> { "role" })
            };
        
    }
}
