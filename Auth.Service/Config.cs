using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace Auth.Service
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                
                new Client
             {
                 RequirePkce = false,
                 ClientId = "ruleEngine",
                 ClientName = "rule engine",
                 ClientSecrets = { new Secret("test".Sha256()) },

                 AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                 AllowOfflineAccess = true,
                 RequireConsent = false,

                 RedirectUris = { "https://localhost:7004/signin-oidc" },
                 PostLogoutRedirectUris =
                   { "https://localhost:7004/signout-callback-oidc" },

                 AllowedScopes =
                 {
                     IdentityServerConstants.StandardScopes.OpenId,
                     IdentityServerConstants.StandardScopes.Profile,
                     "roles"
                 },
                 AllowAccessTokensViaBrowser = true
                 
             }
            };
        public static IEnumerable<ApiScope> apiScopes =>
            new ApiScope[]
            {
                new ApiScope("ruleAPI","rule API")
            };
        public static IEnumerable<ApiResource> apiResources =>
            new ApiResource[]
            {

            };
        public static IEnumerable<IdentityResource> identityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", "User role", new List<string> { "role" })
            };
        public static List<TestUser> testUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId="5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username="admin1",
                    Password="adminp",
                    Claims=new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName,"admin"),
                        new Claim(JwtClaimTypes.FamilyName,"testadmin"),
                        new Claim(JwtClaimTypes.Role,"Admin")
                    }
                },
                new TestUser
                {
                    SubjectId="6BE86359-074C-435B-AD2D-A3932232DABE",
                    Username="user",
                    Password="password",
                    Claims=new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName,"user1"),
                        new Claim(JwtClaimTypes.FamilyName,"test"),
                        new Claim(JwtClaimTypes.Role,"user")
                    }
                }
            };

        
    }
}
