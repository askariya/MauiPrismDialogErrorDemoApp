using CommunityToolkit.Maui;
using MauiPrismDialogErrorDemoApp.Services;
using MauiPrismDialogErrorDemoApp.ViewModel;
using MauiPrismDialogErrorDemoApp.Views;
using Microsoft.Extensions.Logging;
using Prism.Plugin.Popups;

namespace MauiPrismDialogErrorDemoApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UsePrism(prism =>
                {
                    prism.RegisterTypes(container =>
                    {
                        container.RegisterForNavigation<MainPage, MainPageViewModel>();
                        container.RegisterDialog<PopupNotificationDialog, PopupNotificationDialogViewModel>();
                        container.RegisterSingleton<ICustomPopupService, CustomPopupService>();
                    });
                    prism.ConfigureMopupDialogs();
                    prism.CreateWindow(navigationService => navigationService.CreateBuilder()
                                                                             .UseAbsoluteNavigation()
                                                                             .AddNavigationPage()
                                                                             .AddSegment<MainPageViewModel>()
                                                                             .NavigateAsync());
                    prism.ConfigureMopupDialogs();
                })
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
