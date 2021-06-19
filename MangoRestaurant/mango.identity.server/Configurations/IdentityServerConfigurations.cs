using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.identity.server.Configurations
{
    public static class IdentityServerConfigurations
    {
        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>()
                                                                          {   new IdentityResources.OpenId() ,
                                                                              new IdentityResources.Email(),
                                                                              new IdentityResources.Profile()
                                                                          };


        public static IEnumerable<ApiScope> Scopes => new List<ApiScope>() { new ApiScope("mango", "Mango Server"),
                                                                            new ApiScope("read", "Read Data"),
                                                                            new ApiScope("write", "Write Data"),
                                                                            new ApiScope("delete", "Delete Data") };
        public static IEnumerable<Client> Clients => new List<Client>()
        {
            new Client(){ClientId="client",
                ClientSecrets={new Secret("secret".Sha256())},
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                AllowedScopes={"read","write","profile"} },
            new Client(){ClientId="mango",
                ClientSecrets={new Secret("secret".Sha256())},
                AllowedGrantTypes=GrantTypes.Code,
                AllowedScopes=new List<string>(){
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.Email,
                "mango"
                },
                RedirectUris={ "https://localhost:44331/sigin-oidc" },
                PostLogoutRedirectUris={"https://localhost:44331/sign-out-callback-oidc"}

            }
        };
    }
}
