namespace MauiAppTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupNotificationDialog
    {
        private DisplayOrientation _lastKnownOrientation = DisplayOrientation.Unknown;

        public PopupNotificationDialog()
        {
            InitializeComponent();
        }
    }
}