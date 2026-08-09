using Microsoft.Extensions.Localization;
using Engtech.BackOffice.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Engtech.BackOffice.Blazor;

[Dependency(ReplaceServices = true)]
public class BackOfficeBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<BackOfficeResource> _localizer;

    public BackOfficeBrandingProvider(IStringLocalizer<BackOfficeResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
