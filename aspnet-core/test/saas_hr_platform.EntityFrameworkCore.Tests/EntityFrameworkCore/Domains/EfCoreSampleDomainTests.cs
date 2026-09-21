using saas_hr_platform.Samples;
using Xunit;

namespace saas_hr_platform.EntityFrameworkCore.Domains;

[Collection(saas_hr_platformTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<saas_hr_platformEntityFrameworkCoreTestModule>
{

}
