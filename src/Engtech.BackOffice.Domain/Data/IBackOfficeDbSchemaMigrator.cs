using System.Threading.Tasks;

namespace Engtech.BackOffice.Data;

public interface IBackOfficeDbSchemaMigrator
{
    Task MigrateAsync();
}
