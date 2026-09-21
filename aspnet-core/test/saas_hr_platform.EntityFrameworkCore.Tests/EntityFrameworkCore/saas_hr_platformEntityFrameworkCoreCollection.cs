using Xunit;

namespace saas_hr_platform.EntityFrameworkCore;

[CollectionDefinition(saas_hr_platformTestConsts.CollectionDefinitionName)]
public class saas_hr_platformEntityFrameworkCoreCollection : ICollectionFixture<saas_hr_platformEntityFrameworkCoreFixture>
{

}
