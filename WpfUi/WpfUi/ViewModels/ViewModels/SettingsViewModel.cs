using System.Threading.Tasks;
using System.Windows.Input;
using WpfUi.Commands;
using WpfUi.Helpers;
using WpfUi.Models;
using WpfUi.State.Authenticators;
using WpfUi.State.Navigators;
using WpfUi.ViewModels.Factories;

namespace WpfUi.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly IApiHelper _apihelper;
        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;
        public ICommand RestoreDefaultSettingsCommand { get; set; }
        public ICommand SaveSettingsCommand { get; set; }
        private readonly IViewModelFactory _viewModelFactory;


        public SettingsViewModel(IApiHelper apiHelper, IAuthenticator authenticator, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            _navigator = navigator;

            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;
            _apihelper = apiHelper;
            _ = LoadUserSettings();
            RestoreDefaultSettingsCommand = new RestoreDefaultSettingsCommand(this, _apihelper, _authenticator, _navigator , _viewModelFactory);
            SaveSettingsCommand = new SaveSettingsCommand(_apihelper, this, _authenticator, _viewModelFactory, _navigator, _apihelper);
        }





        private SettingsModel _settings;
        public SettingsModel Settings
        {
            get
            {
                HasSaved = false;
               // _navigator.NavigatorViewModel = new NavigationBarViewModel(_navigator , _viewModelFactory, _authenticator, _apihelper);
                return _settings;
            }

            set
            {
                _settings = value;
                OnPropertyChanged(nameof(Settings));

            }
        }


        private bool _hasSaved;

        public bool HasSaved
        {
            get { return _hasSaved; }
            set
            { 
                _hasSaved = value;
                OnPropertyChanged(nameof(HasSaved));
                
            }
        }




        private async Task LoadUserSettings()
        {
            Settings = await _apihelper.GetSettingsForUser(_authenticator.CurrentUser.Id);

        }
    }
}
