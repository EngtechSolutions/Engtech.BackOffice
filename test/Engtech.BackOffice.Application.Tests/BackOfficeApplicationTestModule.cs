using Volo.Abp.Modularity;

namespace Engtech.BackOffice;

[DependsOn(
    typeof(BackOfficeApplicationModule),
    typeof(BackOfficeDomainTestModule)
)]
public class BackOfficeApplicationTestModule : AbpModule
{

}
