using Mathys.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mathys.Services.Services
{
    public class PageService : IPageService
    {
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task DisplayAlert(string title, string message, string ok)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, ok);
        }

        public async Task PopAsync(INavigation navigation)
        {
            await navigation.PopAsync(true);
        }

        public async Task PushAsync(INavigation navigation, Page page)
        {
            await navigation.PushAsync(page, true);
        }
    }
}
