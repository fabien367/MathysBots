using Mathys.Controllers.Base;
using Plugin.FilePicker;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;
using Mathys.Services.IServices;
using Mathys.Services.Services;
using Mathys.DepenciesServices.IServices;
using Windows.Storage;
using Mathys.Models;
using System.Linq;

namespace Mathys.Controllers.ViewModels
{
    public class CreateItemPageViewModel : BaseViewModel
    {
        #region Properties
        private readonly IPageService _pageService;
        private string _excelFileName = "template_newItem.xls";

        private string _fileName = "Chosen file: ";
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; OnPropertyChanged("FileName"); }
        }

        private string _modelName;
        public string ModelName
        {
            get { return _modelName; }
            set
            {
                _modelName = value;
                if (string.IsNullOrEmpty(_modelName))
                {
                    IsLoadAvailable = true;
                    LoadOpacity = 0.5f;
                    IsSendAvailable = true;
                    SendOpacity = 0.5f;
                }
                else
                {
                    IsLoadAvailable = false;
                    LoadOpacity = 1;
                    if (!string.IsNullOrEmpty(ItemModel.ItemName))
                    {
                        SendOpacity = 1;
                        IsSendAvailable = false;
                    }
                }
                OnPropertyChanged("ModelName");
            }
        }
        
        private ItemModel _itemModel = new ItemModel();
        public ItemModel ItemModel
        {
            get { return _itemModel; }
            set {
                _itemModel = value;
                if (string.IsNullOrEmpty(_itemModel.ItemName))
                {
                    IsSendAvailable = true;
                    SendOpacity = 0.5f;
                }
                else
                {
                    IsSendAvailable = false;
                    SendOpacity = 1;
                }
                OnPropertyChanged("ItemModel");
            }
        }

        private float _loadOpacity = 0.5f;
        public float LoadOpacity
        {
            get { return _loadOpacity; }
            set { _loadOpacity = value; OnPropertyChanged("LoadOpacity"); }
        }

        private bool _isLoadAvailable = true;
        public bool IsLoadAvailable
        {
            get { return _isLoadAvailable; }
            set { _isLoadAvailable = value; OnPropertyChanged("IsLoadAvailable"); }
        }

        private float _sendOpacity = 0.5f;
        public float SendOpacity
        {
            get { return _sendOpacity; }
            set { _sendOpacity = value; OnPropertyChanged("SendOpacity"); }
        }

        private bool _isSendAvailable = true;
        public bool IsSendAvailable
        {
            get { return _isSendAvailable; }
            set { _isSendAvailable = value; OnPropertyChanged("IsSendAvailable"); }
        }

        private bool _block1Anim;
        public bool Block1Anim
        {
            get { return _block1Anim; }
            set { _block1Anim = value; OnPropertyChanged("Block1Anim"); }
        }

        private bool _block2Anim;
        public bool Block2Anim
        {
            get { return _block2Anim; }
            set { _block2Anim = value; OnPropertyChanged("Block2Anim"); }
        }

        private bool _block3Anim;
        public bool Block3Anim
        {
            get { return _block3Anim; }
            set { _block3Anim = value; OnPropertyChanged("Block3Anim"); }
        }

        private bool _block4Anim;
        public bool Block4Anim
        {
            get { return _block4Anim; }
            set { _block4Anim = value; OnPropertyChanged("Block4Anim"); }
        }

        public ICommand ChooseFileCommand
        {
            get { return new Command(async () => await ChooseFile()); }
        }

        public ICommand DownloadTemplateCommand
        {
            get { return new Command(async () => await DownloadTemplate()); }
        }

        public ICommand SendItemCommand
        {
            get { return new Command(async () => await SendItem()); }
        }
        
        #endregion

        #region CTR
        public CreateItemPageViewModel(INavigation navigation)
        {
            _pageService = new PageService();
        }
        #endregion

        public async Task DownloadTemplate()
        {
            try
            {
                var documentStream = EmbeddedDocuments.GetDocumentStream("Mathys.Services.Documents.template_newItem.xls");
                if (documentStream != null)
                {
                    if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                    {
                        var path = DependencyService.Get<IExternalStorageFolder>().GetExternalPath();
                        var filePath = Path.Combine(path, _excelFileName);
                        if (!File.Exists(filePath))
                        {
                            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                            {
                                documentStream.CopyTo(fs);
                                await _pageService.DisplayAlert("Success", "File successfully downloaded in 'Documents' folder.", "OK");
                            }
                        }
                        else
                            await _pageService.DisplayAlert("Success", "File already downloaded in 'Documents' folder.", "OK");
                    }
                    else if (Device.RuntimePlatform == Device.UWP)
                    {
                        var kek = await DependencyService.Get<ICreateFileInDownloads>().CreateFile(_excelFileName, documentStream);
                        if (kek)
                            await _pageService.DisplayAlert("Success", "File successfully downloaded in 'Documents' folder.", "OK");
                        else
                            await _pageService.DisplayAlert("Error", "Error while creating the file", "OK");
                    }
                }
                else
                    await _pageService.DisplayAlert("Error", "File not found", "OK");
            }
            catch (Exception ex)
            {
                await _pageService.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public async Task ChooseFile()
        {
            ItemModel = new ItemModel();
            try
            {
                var file = await CrossFilePicker.Current.PickFile();
                if (file != null)
                {
                    if (file.FileName.Split('.').Last() != "xls")
                        await _pageService.DisplayAlert("Error", "You must chose an Excel file (97-2003) with extension '.xls'.", "OK");
                    else
                    {
                        FileName = string.Concat("Chosen file: ", file.FileName);
                        ItemModel = new ItemModel { ItemName = ModelName, ItemContent = file.DataArray };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SendItem()
        {
            try
            {
                IItemService itemService = new ItemService();

                if (await itemService.AddNewItem(ItemModel))
                    await _pageService.DisplayAlert("Success", "Item successfully added.", "OK");
                else
                    await _pageService.DisplayAlert("Error", "Error while saving new item. Please, check that the template is correctly filled.", "OK");
            }
            catch (Exception ex)
            {
                await _pageService.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
