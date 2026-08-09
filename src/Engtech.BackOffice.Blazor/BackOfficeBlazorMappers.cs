using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using Engtech.BackOffice.Authors;
using Engtech.BackOffice.Books;
namespace Engtech.BackOffice.Blazor;
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class BackOfficeBlazorMappers : MapperBase<BookDto, CreateUpdateBookDto>
{
    public override partial CreateUpdateBookDto Map(BookDto source);
    public override partial void Map(BookDto source, CreateUpdateBookDto destination);
}
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class BackOfficeAuthorDtoToCreateUpdateAuthorDtoMapper : MapperBase<AuthorDto, CreateUpdateAuthorDto>
{
    public override partial CreateUpdateAuthorDto Map(AuthorDto source);
    public override partial void Map(AuthorDto source, CreateUpdateAuthorDto destination);
}
