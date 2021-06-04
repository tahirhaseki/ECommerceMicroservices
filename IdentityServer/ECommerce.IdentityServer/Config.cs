﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace ECommerce.IdentityServer
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("resource_catalog"){Scopes={"catalog_fullpermission","catalog_r_permission","catalog_we_permission"}},
                new ApiResource("resource_photo_stock"){Scopes={"photo_stock_fullpermission","photo_stock_r_permission","photo_stock_we_permission"}},
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)

            };
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                       new IdentityResources.OpenId(),
                       new IdentityResources.Profile(),
                       new IdentityResource(){Name="roles",DisplayName="Roles",Description="User Roles",UserClaims=new []{"role"}}
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission","Catalog Api Tam Erişim"),
                new ApiScope("catalog_r_permission","Catalog Api Read Erişim"),
                new ApiScope("catalog_we_permission","Catalog Api Write/Edit Erişim"),
                new ApiScope("photo_stock_fullpermission","Photostock Api Tam Erişim"),
                new ApiScope("photo_stock_r_permission","Photostock Api Read Erişim"),
                new ApiScope("photo_stock_we_permission","Photostock Api Write/Edit Erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName="ECommerce MVC",
                    ClientId="WebMvcClient",
                    ClientSecrets={new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={ "catalog_fullpermission","catalog_r_permission","catalog_we_permission", 
                                    "photo_stock_fullpermission","photo_stock_r_permission","photo_stock_we_permission",
                                    IdentityServerConstants.LocalApi.ScopeName}
                },
                new Client
                {
                    ClientName="ECommerce MVC User",
                    ClientId="WebMvcClientForUser",
                    AllowOfflineAccess=true,
                    ClientSecrets={new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    AllowedScopes={IdentityServerConstants.StandardScopes.Email,
                                   IdentityServerConstants.StandardScopes.OpenId,
                                   IdentityServerConstants.StandardScopes.Profile,
                                   IdentityServerConstants.StandardScopes.OfflineAccess,
                                   IdentityServerConstants.LocalApi.ScopeName},
                    AccessTokenLifetime=1*60*60,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime=(int) (DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                    RefreshTokenUsage=TokenUsage.ReUse
                },
            };
    }
}