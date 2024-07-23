namespace MauiAppTest.ViewModel
{
    public class PopupNotificationDialogViewModel : BindableBase, IDialogAware
    {
        public Command PositiveCommand { get; private set; }
        public Command NegativeCommand { get; private set; }

        public PopupNotificationDialogViewModel()
        {
            PositiveCommand = new Command(OnPositivePressed, PositiveCanExecute);
            NegativeCommand = new Command(OnNegativePressed, NegativeCanExecute);
        }

        public string NegativeButtonText
        {
            get { return "Cancel"; }
        }

        public string PositiveButtonText
        {
            get { return "OK"; }
        }

        bool PositiveCanExecute()
        {
            return true;
        }
        bool NegativeCanExecute()
        {
            return true;
        }
        private void OnPositivePressed()
        {
            Finish(ButtonResult.Yes);
        }
        private void OnNegativePressed()
        {
            Finish(ButtonResult.No);
        }

        public string Header
        {
            get { return "Popup Notification"; }
        }

        public string Message
        {
            get { return "This is a popup notification!"; }
        }

        public DialogCloseListener RequestClose { get; }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void Finish(ButtonResult result)
        {
            RequestClose.Invoke();
        }

        bool IDialogAware.CanCloseDialog()
        {
            return true;
        }

        void IDialogAware.OnDialogClosed()
        {
        }

        void IDialogAware.OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
