using Duende.IdentityServer.Models;

namespace SsoSample.IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope> {

            new ApiScope(name: "api1", displayName: "Weather Forecast")
        };

    public static IEnumerable<Client> Clients =>
        new List<Client> {

            new Client {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {

                    new Secret("secret".Sha256())
                },
                AllowedScopes = {"api1"}
            }
        };
}