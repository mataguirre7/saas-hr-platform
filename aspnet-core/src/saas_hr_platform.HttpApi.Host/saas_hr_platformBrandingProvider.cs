using Microsoft.Extensions.Localization;
using saas_hr_platform.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace saas_hr_platform;

[Dependency(ReplaceServices = true)]
public class saas_hr_platformBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<saas_hr_platformResource> _localizer;

    public saas_hr_platformBrandingProvider(IStringLocalizer<saas_hr_platformResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
