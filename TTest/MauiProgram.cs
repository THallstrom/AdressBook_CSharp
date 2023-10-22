using TTest.Mvvm.ViewModels;
using TTest.Mvvm.Views;
using TTest.Services;

namespace TTest
{
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

            

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModel>();

            builder.Services.AddTransient<AddPage>();
            builder.Services.AddTransient<AddViewModel>();

            builder.Services.AddTransient<DetailPage>();
            builder.Services.AddTransient<DetailViewModel>();

            builder.Services.AddTransient<EditPage>();
            builder.Services.AddTransient<EditViewModel>();

            return builder.Build();
        }
    }
}