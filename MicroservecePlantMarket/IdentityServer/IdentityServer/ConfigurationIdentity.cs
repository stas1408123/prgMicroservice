using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class ConfigurationIdentity
    {
        public static IEnumerable<Client> GetClients() =>

             new List<Client>
             {

                new Client
                {
                    ClientId = "client_id",
                    ClientSecrets = { new Secret("client_secret".ToSha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes =
                    {
                    "PlantApi",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                    }
                },

                new Client
                {
                    ClientId = "client_id_api",
                    ClientSecrets = { new Secret("client_secret_api".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes =
                    {
                    "PlantApi",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                    },
                    RedirectUris = {"https://localhost:5001/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:5001/signout-callback-oidc"},
                    RequireConsent = false,
                    //AccessTokenLifetime = 5,
                    AllowOfflineAccess = true
                    // AlwaysIncludeUserClaimsInIdToken = true
                },

                new Client
                {
                    ClientId = "angular",
                    RequireClientSecret=false,
                    RequirePkce=true,
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes =
                    {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "ProductApi",
                    "OrderApi",
                    "ShopCartApi",
                    },
                    RedirectUris = {"https://localhost:5001"},
                    PostLogoutRedirectUris = {"https://localhost:5001"},
                    AllowedCorsOrigins= {"https://localhost:5001" },
                    RequireConsent = false,
                    AllowAccessTokensViaBrowser=true,


                    /*RedirectUris =           { $"{clientsUrl["Spa"]}/" },
                    PostLogoutRedirectUris = { $"{clientsUrl["Spa"]}/" },
                    AllowedCorsOrigins =     { $"{clientsUrl["Spa"]}" },*/


                    //AccessTokenLifetime = 5,
                    //AllowOfflineAccess = true
                    // AlwaysIncludeUserClaimsInIdToken = true
                }




              };

        public static IEnumerable<ApiResource> GetApiResources() =>
            new List<ApiResource>
            {
                new ApiResource("ProductApi"),
                new ApiResource("OrderApi"),
                new ApiResource("ShopCartApi"),
            };




        public static IEnumerable<IdentityResource> GetIdentityResources() =>

            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            yield return new ApiScope("ProductApi", "ProductApi");
            yield return new ApiScope("OrderApi", "OrderApi");
            yield return new ApiScope("ShopCartApi", "ShopCartApi");
        }

    }
}
