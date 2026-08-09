using Engtech.BackOffice.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Engtech.BackOffice.Permissions;

public class BackOfficePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BackOfficePermissions.GroupName);

        var booksPermission = myGroup.AddPermission(BackOfficePermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(BackOfficePermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(BackOfficePermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(BackOfficePermissions.Books.Delete, L("Permission:Books.Delete"));

        var authorsPermission = myGroup.AddPermission(BackOfficePermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(BackOfficePermissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(BackOfficePermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(BackOfficePermissions.Authors.Delete, L("Permission:Authors.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BackOfficePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BackOfficeResource>(name);
    }
}
