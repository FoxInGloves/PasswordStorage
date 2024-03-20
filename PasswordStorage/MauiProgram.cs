using Microsoft.Extensions.Logging;
using Notes_MAUI;
using Notes_MAUI.Views;
using PasswordStorage.Services;
using PasswordStorage.Services.Interface;
using PasswordStorage.ViewModels.Implementation;
using PasswordStorage.Views;

namespace PasswordStorage;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();

        builder.Services.AddTransient<DataPage>();
        builder.Services.AddTransient<DataPageViewModel>();

        builder.Services.AddSingleton<INavigationService, NavigationService>();
        
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}