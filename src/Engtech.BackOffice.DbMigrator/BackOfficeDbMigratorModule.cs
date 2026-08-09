using Engtech.BackOffice.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Engtech.BackOffice.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BackOfficeEntityFrameworkCoreModule),
    typeof(BackOfficeApplicationContractsModule)
)]
public class BackOfficeDbMigratorModule : AbpModule
{
}
