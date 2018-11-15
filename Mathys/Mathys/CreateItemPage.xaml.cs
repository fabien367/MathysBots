using Mathys.Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mathys
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateItemPage : ContentPage
	{
        private readonly CreateItemPageViewModel _createPageContext;

		public CreateItemPage ()
		{
			InitializeComponent ();
            _createPageContext = new CreateItemPageViewModel(Navigation);
            BindingContext = _createPageContext;
        }

        protected override void OnAppearing()
        {
            Task.Run(() => SetTranslations());
            base.OnAppearing();
        }

        private async void SetTranslations()
        {
            _createPageContext.Block1Anim = true;
            await Task.Delay(100);
            _createPageContext.Block2Anim = true;
            await Task.Delay(100);
            _createPageContext.Block3Anim = true;
            await Task.Delay(100);
            _createPageContext.Block4Anim = true;
        }
    }
}