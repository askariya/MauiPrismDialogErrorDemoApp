using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;
using MauiPrismDialogErrorDemoApp.Services;
using MauiPrismDialogErrorDemoApp.Views;
using Mopups.PreBaked.PopupPages.DualResponse;

namespace MauiPrismDialogErrorDemoApp.ViewModel
{
    public partial class MainPageViewModel : BindableBase
    {
        public DelegateCommand DisplayPopupCommand { get; }
        public DelegateCommand AbsoluteNavigationCommand { get; }

        private INavigationService _navigationService;
        private IDialogService _dialogService;
        private ICustomPopupService _popupService;

        public MainPageViewModel(INavigationService navigationService, ICustomPopupService popupService, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _popupService = popupService;

            DisplayPopupCommand = new DelegateCommand(DisplayMopup).ObservesProperty(() => IsBusy);
            AbsoluteNavigationCommand = new DelegateCommand(PerformAbsoluteNavigation).ObservesProperty(() => IsBusy);
        }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public async void DisplayMopup()
        {
            // Trigger popupService
            var popupResult = await _popupService.PopupTest();
            if (popupResult == ButtonResult.None)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();
            }


            // Trigger locally
            //var popupResult = await _dialogService.ShowDialogAsync(nameof(PopupNotificationDialog));

            //if (popupResult.Result == ButtonResult.None)
            //{
            //    if (System.Diagnostics.Debugger.IsAttached)
            //        System.Diagnostics.Debugger.Break();
            //}
        }

        public async void PerformAbsoluteNavigation()
        {
            var navResult = await _navigationService.CreateBuilder()
                                                    .UseAbsoluteNavigation()
                                                    .AddNavigationPage()
                                                    .AddSegment<MainPageViewModel>()
                                                    .NavigateAsync();
            if(!navResult.Success)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();
            }
        }

    }
}
