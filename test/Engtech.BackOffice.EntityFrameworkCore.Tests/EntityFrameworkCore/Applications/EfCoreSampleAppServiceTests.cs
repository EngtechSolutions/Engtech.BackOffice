using Engtech.BackOffice.Samples;
using Xunit;

namespace Engtech.BackOffice.EntityFrameworkCore.Applications;

[Collection(BackOfficeTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<BackOfficeEntityFrameworkCoreTestModule>
{

}
