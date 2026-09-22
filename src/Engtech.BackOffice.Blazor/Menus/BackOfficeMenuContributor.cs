using System.Threading.Tasks;
using Engtech.BackOffice.Localization;
using Engtech.BackOffice.Permissions;
using Engtech.BackOffice.MultiTenancy;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;
using Volo.Abp.SettingManagement.Blazor.MudBlazor.Menus;
using Volo.Abp.TenantManagement.Blazor.MudBlazor.Navigation;
using Volo.Abp.Identity.Blazor.MudBlazor;
namespace Engtech.BackOffice.Blazor.Menus;
public class BackOfficeMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }
    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<BackOfficeResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                BackOfficeMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 1
            )
        );
        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 6;

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        // context.Menu.AddItem(
        //     new ApplicationMenuItem(
        //         "BooksStore",
        //         l["Menu:BackOffice"],
        //         icon: "fa fa-book"
        //     ).AddItem(
        //         new ApplicationMenuItem(
        //             "BooksStore.Books",
        //             l["Menu:Books"],
        //             url: "/books"
        //         ).RequirePermissions(BackOfficePermissions.Books.Default)
        //     ).AddItem(
        //         new ApplicationMenuItem(
        //             "BooksStore.Authors",
        //             l["Menu:Authors"],
        //             url: "/authors"
        //         ).RequirePermissions(BackOfficePermissions.Authors.Default)
        //     )
        // );
        return Task.CompletedTask;
    }
}
