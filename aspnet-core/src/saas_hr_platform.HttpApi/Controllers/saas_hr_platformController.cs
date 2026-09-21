using saas_hr_platform.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace saas_hr_platform.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class saas_hr_platformController : AbpControllerBase
{
    protected saas_hr_platformController()
    {
        LocalizationResource = typeof(saas_hr_platformResource);
    }
}
