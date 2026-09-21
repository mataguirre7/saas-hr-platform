using saas_hr_platform.Samples;
using Xunit;

namespace saas_hr_platform.EntityFrameworkCore.Applications;

[Collection(saas_hr_platformTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<saas_hr_platformEntityFrameworkCoreTestModule>
{

}
