using System;
using System.Collections.Generic;
using System.Text;
using saas_hr_platform.Localization;
using Volo.Abp.Application.Services;

namespace saas_hr_platform;

/* Inherit your application services from this class.
 */
public abstract class saas_hr_platformAppService : ApplicationService
{
    protected saas_hr_platformAppService()
    {
        LocalizationResource = typeof(saas_hr_platformResource);
    }
}
