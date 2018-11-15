using Mathys.Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mathys
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _mainPageContext;
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _mainPageContext = new MainPageViewModel(typeof(CreateItemPage), Navigation);
            BindingContext = _mainPageContext;
        }
        
        protected override void OnAppearing()
        {
            _mainPageContext.TitleAnim = true;
            _mainPageContext.UserAnim = true;
            _mainPageContext.ButtonAnim = true;
            base.OnAppearing();
        }
    }
}
