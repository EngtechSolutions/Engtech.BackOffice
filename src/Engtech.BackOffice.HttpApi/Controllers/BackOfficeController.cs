using Engtech.BackOffice.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Engtech.BackOffice.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BackOfficeController : AbpControllerBase
{
    protected BackOfficeController()
    {
        LocalizationResource = typeof(BackOfficeResource);
    }
}
