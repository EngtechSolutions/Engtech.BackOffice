using Engtech.BackOffice.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Engtech.BackOffice.Blazor;

public abstract class BackOfficeComponentBase : AbpComponentBase
{
    protected BackOfficeComponentBase()
    {
        LocalizationResource = typeof(BackOfficeResource);
    }
}
