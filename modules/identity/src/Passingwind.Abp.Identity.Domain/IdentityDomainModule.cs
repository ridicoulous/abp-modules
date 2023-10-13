﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Domain;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;

namespace Passingwind.Abp.Identity;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(AbpIdentityDomainModule),
    typeof(IdentityDomainSharedModule)
)]
public class IdentityDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddScoped<IdentityUserManager>();
        context.Services.TryAddScoped(typeof(UserManager<IdentityUser>), provider => provider.GetRequiredService(typeof(IdentityUserManager)));

        context.Services.AddAbpDynamicOptions<IdentityOptions, IdentityOptionsManager>();
    }
}