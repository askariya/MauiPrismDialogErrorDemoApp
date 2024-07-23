using CommunityToolkit.Mvvm.Input;
using MauiAppTest.Views;
using Mopups.PreBaked.PopupPages.DualResponse;

namespace MauiAppTest.ViewModel
{
    public partial class MainPageViewModel
    {
        private IDialogService _dialogService;
        public MainPageViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        [RelayCommand]
        public async Task DisplayMopup()
        {
            var fileData = await FilePicker.PickAsync();
            var popupResult = await _dialogService.ShowDialogAsync(nameof(PopupNotificationDialog));
        }

    }
}
