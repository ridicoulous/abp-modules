﻿using Passingwind.Abp.FileManagement;
using Passingwind.Abp.IdentityClientManagement;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Sample;

[DependsOn(
    typeof(SampleDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(SampleApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
[DependsOn(typeof(FileManagementApplicationModule))]
[DependsOn(typeof(IdentityClientManagementApplicationModule))]
public class SampleApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<SampleApplicationModule>();
        });
    }
}
