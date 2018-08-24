using System;
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Server
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiReosource()
        {
            return new List<ApiResource>{
                new ApiResource("api1","My API")
            };
        }

        public static IEnumerable<Client> GetClients(){
            return new List<Client>{
                new Client{
                    ClientId="client",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets={
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={ "api1"},

                },
                new Client{
                    ClientId="re.client",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    ClientSecrets={
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={"api1"}
                },
                new Client{
                    ClientId="implicit",
                    ClientName="SPA",
                    ClientSecrets={
                        new Secret("secret".Sha256())
                    },
                    AllowAccessTokensViaBrowser=true,
                    AllowedGrantTypes= GrantTypes.Implicit,
                    RedirectUris={ "http://localhost:4200"},
                    AllowedScopes= {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Phone
                                               
                    },
                    AllowedCorsOrigins={
                        "http://localhost:4200"
                    },
                    PostLogoutRedirectUris={
                        "http://localhost:4200"
                    }
                }
            };
        }

        public static List<TestUser> GetUsers(){
            return new List<TestUser>{
                new TestUser{
                    SubjectId="1",
                    Username="alice",
                    Password="password"
                },
                new TestUser{
                    SubjectId="2",
                    Username="bob",
                    Password="password"
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
              {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
              };
        }


    }
    
}
