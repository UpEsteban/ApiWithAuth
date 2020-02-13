using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> Ids => new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> Apis =>
                   new List<ApiResource>
                   {
                       new ApiResource("api1", "My API"),
                       new ApiResource("roles", "My Roles", new[] { "role" })
                   };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("123465".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1", "roles" }
                }
            };
    }
}
