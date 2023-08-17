using IdentityServer4.Models;
using System.Collections;
using System.Reflection.Metadata.Ecma335;
using IdentityServer4.Test;
using System.Threading.Tasks;
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Validation;
using System.Security.Claims;
using IdentityModel;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                 new Client
                {
                    ClientId = "angular-web-app",
                    ClientName = "Angular Web App",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce=false,

                    RedirectUris =           { "http://localhost:4200/signin-callback" },
                    PostLogoutRedirectUris = { "http://localhost:4200/signout-callback" },
                    AllowedCorsOrigins =     { "http://localhost:4200" },

                    AllowedScopes= new List<string>()
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Email,
                        "securityAppAPI",
                        "roles"
                    }
                },
                new Client
                {
                    ClientId="mvc_client",
                    ClientName="MVC Web App",
                    AllowedGrantTypes=GrantTypes.Hybrid,
                    RequirePkce=false,
                    AllowRememberConsent=false,
                    RedirectUris= new List<string>()
                    {
                        "https://localhost:5002/signin-oidc" //this is client app port
                    },
                    PostLogoutRedirectUris= new List<string>()
                    {
                        "https://localhost:5002/signout-callback-oidc"
                    },
                    ClientSecrets= new List<Secret>()
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes= new List<string>()
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Email,
                        "securityAppAPI",
                        "roles"
                    }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("securityAppAPI", "Security App API")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[] { };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[] {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Address(),
            new IdentityResources.Email(),
            new IdentityResource(
                "roles",
                "Your roles(s)",
                new List<string>(){"role"})
            };
    }
}
