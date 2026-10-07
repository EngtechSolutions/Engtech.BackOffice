using System;
using System.Threading.Tasks;
using Engtech.BackOffice.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using MudBlazor;
using Volo.Abp.AspNetCore.Components;

namespace Engtech.BackOffice.Blazor;

public abstract class BackOfficeComponentBase : AbpComponentBase
{
    [Inject]
    private ISnackbar Snackbar { get; set; } = default!;
    
    protected BackOfficeComponentBase()
    {
        LocalizationResource = typeof(BackOfficeResource);
    }

    protected async Task HandleErrorAsync(Exception ex, string operation = "Operación")
    {
        Logger.LogError(ex, "{Operation} failed", operation);
            
        var message = GetFriendlyMessage(ex);
        Snackbar.Add($"{operation} fallida", Severity.Error);
    }

    private static string GetFriendlyMessage(Exception ex)
    {
        return ex switch
        {
            UnauthorizedAccessException => "Acceso denegado. No tienes los permisos necesarios.",
            ArgumentException => "Datos inválidos. Por favor verifica la información ingresada.",
            InvalidOperationException => "La operación no se puede realizar en este momento.",
            TimeoutException => "La operación tardó demasiado tiempo. Por favor intenta nuevamente.",
            _ => "Ha ocurrido un error inesperado. Por favor intenta nuevamente."
        };
    }
}
