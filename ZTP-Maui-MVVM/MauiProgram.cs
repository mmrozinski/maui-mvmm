using Microsoft.Extensions.Logging;
using Refit;
using ZTP_Maui_MVVM.Clients;
using ZTP_Maui_MVVM.ViewModels;
using ZTP_Maui_MVVM.Views;

namespace ZTP_Maui_MVVM;

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
            })
            .RegisterProductsRefitClient()
            .RegisterViewModels()
            .RegisterViews();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static MauiAppBuilder RegisterProductsRefitClient(this MauiAppBuilder builder)
    {
        builder.Services.AddRefitClient<IProductsClient>()
            .ConfigureHttpClient(c =>
            {
#if ANDROID
                c.BaseAddress = new Uri("http://10.0.2.2:8080/api");
#else
                c.BaseAddress = new Uri("http://localhost:8080/api");
#endif
                c.Timeout = TimeSpan.FromSeconds(5);
            }); 

        return builder;
    }

    private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<NewProductViewModel>();
        builder.Services.AddTransient<ProductListViewModel>();
        builder.Services.AddTransient<ProductViewModel>();
        return builder;
    }

    private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<NewProductView>();
        builder.Services.AddSingleton<ProductListView>();
        builder.Services.AddSingleton<ProductView>();
        return builder;
    }
}