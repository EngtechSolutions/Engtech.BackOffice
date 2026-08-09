using Engtech.BackOffice.Localization;
using Volo.Abp.Application.Services;

namespace Engtech.BackOffice;

/* Inherit your application services from this class.
 */
public abstract class BackOfficeAppService : ApplicationService
{
    protected BackOfficeAppService()
    {
        LocalizationResource = typeof(BackOfficeResource);
    }
}
