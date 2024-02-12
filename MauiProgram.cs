using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using AppPruebaV1.DataAccess;
using AppPruebaV1.Pages;
using AppPruebaV1.ViewModels;

namespace AppPruebaV1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddDbContext<VentaDbContext>();

            builder.Services.AddTransient<CategoriasPage>();
            builder.Services.AddTransient<CategoriasVM>();

            builder.Services.AddTransient<InventarioPage>();
            builder.Services.AddTransient<InventarioVM>();

            builder.Services.AddTransient<ProductoPage>();
            builder.Services.AddTransient<ProductoVM>();

            builder.Services.AddTransient<VentaPage>();
            builder.Services.AddTransient<VentaVM>();

            builder.Services.AddTransient<BuscarProductoPage>();
            builder.Services.AddTransient<BuscarProductoVM>();

            builder.Services.AddTransient<HistoriaVentaPage>();
            builder.Services.AddTransient<HistorialVentaVM>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainVM>();

            var dbContext = new VentaDbContext();
            dbContext.Database.EnsureCreated();
            dbContext.Dispose();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
