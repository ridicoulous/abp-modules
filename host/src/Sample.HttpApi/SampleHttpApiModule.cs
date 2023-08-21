﻿using Localization.Resources.AbpUi;
using Passingwind.Abp.FileManagement;
using Sample.Localization;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.BlobStoring.FileSystem;
using Passingwind.Abp.IdentityClientManagement;

namespace Sample;

[DependsOn(
    typeof(SampleApplicationContractsModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule)
    )]
[DependsOn(typeof(FileManagementHttpApiModule))]
[DependsOn(typeof(AbpBlobStoringFileSystemModule))]
[DependsOn(typeof(IdentityClientManagementHttpApiModule))]
    public class SampleHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<SampleResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
