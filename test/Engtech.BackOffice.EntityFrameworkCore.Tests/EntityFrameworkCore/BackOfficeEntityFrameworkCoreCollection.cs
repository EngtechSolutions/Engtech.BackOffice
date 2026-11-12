using Xunit;

namespace Engtech.BackOffice.EntityFrameworkCore;

[CollectionDefinition(BackOfficeTestConsts.CollectionDefinitionName)]
public class BackOfficeEntityFrameworkCoreCollection : ICollectionFixture<BackOfficeEntityFrameworkCoreFixture>
{

}
