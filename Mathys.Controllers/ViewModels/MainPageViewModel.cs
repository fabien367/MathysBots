using Mathys.Controllers.Base;
using Mathys.Services.IServices;
using Mathys.Services.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mathys.Controllers.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Properties
        private readonly Type _createItemPage;
        private readonly IPageService _pageService;
        private readonly INavigation _navigation;

        private bool _titleAnim;
        public bool TitleAnim
        {
            get { return _titleAnim; }
            set { _titleAnim = value; OnPropertyChanged("TitleAnim"); }
        }

        private bool _userAnim;
        public bool UserAnim
        {
            get { return _userAnim; }
            set { _userAnim = value; OnPropertyChanged("UserAnim"); }
        }

        private bool _buttonAnim;
        public bool ButtonAnim
        {
            get { return _buttonAnim; }
            set { _buttonAnim = value; OnPropertyChanged("ButtonAnim"); }
        }

        public ICommand GoToAddItemCommand
        {
            get { return new Command(async () => await GoToAddItem()); }
        }
        #endregion

        #region CTR
        public MainPageViewModel(Type CreateItemPage, INavigation navigation)
        {
            _createItemPage = CreateItemPage;
            _navigation = navigation;
            _pageService = new PageService();
        }
        #endregion

        private async Task GoToAddItem()
        {
            var page = (Page)Activator.CreateInstance(_createItemPage);
            await _pageService.PushAsync(_navigation, page);
        }
    }
}
