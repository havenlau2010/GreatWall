using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace GreatWall.Configs {
    public class Config {
        public static IEnumerable<IdentityResource> GetIdentityResources() {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources() {
            return new List<ApiResource>
            {
                new ApiResource("user_api", "API"),
                new ApiResource("api", "API")
            };
        }

        public const int AccessTokenLifetime = 90;

        public const string AdminUrl = "http://localhost:10081";

        public static IEnumerable<Client> GetClients() {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "test1",
                    ClientName = "test1",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    AllowedCorsOrigins = { AdminUrl },
                    RequireConsent = false,
                    RedirectUris = { $"{AdminUrl}/callback" },
                    PostLogoutRedirectUris = { AdminUrl },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "user_api",
                        "api"
                    },
                    AccessTokenLifetime = AccessTokenLifetime
                }
            };
        }
    }
}