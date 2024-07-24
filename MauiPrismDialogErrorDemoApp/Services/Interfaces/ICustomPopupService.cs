using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPrismDialogErrorDemoApp.Services
{
    public interface ICustomPopupService
    {
        Task<ButtonResult> PopupTest();
    }
}
