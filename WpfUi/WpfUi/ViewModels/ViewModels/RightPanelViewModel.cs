using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUi.Helpers;
using WpfUi.Models;
using WpfUi.State.Authenticators;
using WpfUi.State.Navigators;
using WpfUi.ViewModels.Factories;

namespace WpfUi.ViewModels
{
    public class RightPanelViewModel : ViewModelBase
    {


        private readonly IAuthenticator _authenticator;
        private readonly IApiHelper _apiHelper;


        public string DarkModeColor1 = "#393B40";
        public string DarkModeColor2 = "#292b2F";
        public string RegularModeColor1 = "WhiteSmoke";
        public string RegularModeColor2 = "LightGray";


        public RightPanelViewModel(IAuthenticator authenticator, IApiHelper apiHelper)
        {
            _authenticator = authenticator;
            _apiHelper = apiHelper;
            User = _authenticator.CurrentUser;
            _ = LoadUserSettings();
        }






        private string _backgroundColor1 = "WhiteSmoke";
        public string BackgroudColor1
        {
            get
            {
                return _backgroundColor1;
            }
            set
            {
                _backgroundColor1 = value;
                OnPropertyChanged(nameof(BackgroudColor1));
            }
        }

        private string _backgroundColor2 = "LightGray";
        public string BackgroudColor2
        {
            get
            {
                return _backgroundColor2;
            }
            set
            {
                _backgroundColor2 = value;
                OnPropertyChanged(nameof(BackgroudColor2));
            }
        }

        private SettingsModel _settings;
        public SettingsModel Settings
        {
            get
            {
                return _settings;
            }

            set
            {
                _settings = value;
                OnPropertyChanged(nameof(Settings));
            }
        }

        private AuthenticatedUser _user;



        public AuthenticatedUser User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private async Task LoadUserSettings()
        {
            Settings = await _apiHelper.GetSettingsForUser(_authenticator.CurrentUser.Id);
            ApplySettings();
        }

        private void ApplySettings()
        {
            if (Settings != null)
            {
                if (Settings.DarkMode)
                {
                    BackgroudColor1 = DarkModeColor1;
                    BackgroudColor2 = DarkModeColor2;

                }
                else
                {
                    BackgroudColor1 = RegularModeColor1;
                    BackgroudColor2 = RegularModeColor2;
                }
            }
            else
            {
                BackgroudColor1 = RegularModeColor1;
                BackgroudColor2 = RegularModeColor2;
            }

        }
    }
}
