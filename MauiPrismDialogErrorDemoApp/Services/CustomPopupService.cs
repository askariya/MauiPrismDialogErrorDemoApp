using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiPrismDialogErrorDemoApp.Views;

namespace MauiPrismDialogErrorDemoApp.Services
{
    public class CustomPopupService : ICustomPopupService
    {
        private INavigationService _navigationService { get; }
        private IDialogService _dialogService { get; }

        public CustomPopupService(INavigationService navigationService,
            IDialogService dialogService) 
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
        }

        public async Task<ButtonResult> PopupTest()
        {
            var dialogResult = await _dialogService.ShowDialogAsync(nameof(PopupNotificationDialog), new DialogParameters{
                {"Header", "header"},
                {"Message", "message" },
                {"Footer", "footer" },
                {"PositiveButtonText", "Yes"},
                {"NegativeButtonText", "No"},
                {"PlaySound", ""} }
            );

            if (dialogResult.Result == ButtonResult.None)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();
            }

            return dialogResult.Result;
        }
    }
}
