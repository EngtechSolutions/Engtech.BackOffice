using Engtech.BackOffice.Samples;
using Xunit;

namespace Engtech.BackOffice.EntityFrameworkCore.Domains;

[Collection(BackOfficeTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<BackOfficeEntityFrameworkCoreTestModule>
{

}
