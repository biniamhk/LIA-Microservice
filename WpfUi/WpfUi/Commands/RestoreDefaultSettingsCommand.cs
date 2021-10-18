using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfUi.Helpers;
using WpfUi.State.Authenticators;
using WpfUi.State.Navigators;
using WpfUi.ViewModels;
using WpfUi.ViewModels.Factories;

namespace WpfUi.Commands
{
    public class RestoreDefaultSettingsCommand : ICommand
    {
        private readonly SettingsViewModel _settingsViewModel;
        private readonly IApiHelper _apihelper;
        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;
        private readonly IViewModelFactory _viewModelFactory;

        public event EventHandler CanExecuteChanged;

        public RestoreDefaultSettingsCommand(SettingsViewModel settings, IApiHelper api, IAuthenticator authenticator, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            _apihelper = api;
            _settingsViewModel = settings;

            _authenticator = authenticator;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _settingsViewModel.PropertyChanged += SettingsViewModel_PropertyChanged;
        }



        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {

                _settingsViewModel.Settings = await _apihelper.RestoreDefaultSettings(_authenticator.CurrentUser.Id);
                _navigator.NavigatorViewModel = new NavigationBarViewModel(_navigator, _viewModelFactory, _authenticator, _apihelper);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

        }


        private void SettingsViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SettingsViewModel.Settings))
            {
                CanExecuteChanged?.Invoke(this, e);
            }
        }



    }
}
