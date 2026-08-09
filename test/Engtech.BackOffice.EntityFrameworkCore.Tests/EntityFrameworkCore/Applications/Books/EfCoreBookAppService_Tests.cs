using Engtech.BackOffice.Books;
using Xunit;

namespace Engtech.BackOffice.EntityFrameworkCore.Applications.Books;

[Collection(BackOfficeTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<BackOfficeEntityFrameworkCoreTestModule>
{

}