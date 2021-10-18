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
    public class SaveSettingsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;


        private readonly IApiHelper _apiHelper;
        private readonly IAuthenticator _authenticator;
        private readonly SettingsViewModel _settingsViewModel;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly INavigator _navigator;
        private readonly IApiHelper _apihelper;

        public SaveSettingsCommand(IApiHelper apiHelper, SettingsViewModel settingsViewModel, IAuthenticator authenticator, IViewModelFactory viewModelFactory, INavigator navigator, IApiHelper apihelper)
        {
            _apiHelper = apiHelper;
            _settingsViewModel = settingsViewModel;
            _settingsViewModel.PropertyChanged += SettingsViewModel_PropertyChanged;
            _authenticator = authenticator;
            _viewModelFactory = viewModelFactory;
            _navigator = navigator;
            _apihelper = apihelper;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                _settingsViewModel.Settings = await _apiHelper.UpdateSettingsForUser(_authenticator.CurrentUser.Id, _settingsViewModel.Settings);
                _settingsViewModel.HasSaved = true;
                _navigator.NavigatorViewModel = new NavigationBarViewModel(_navigator, _viewModelFactory, _authenticator, _apihelper);
                _navigator.RightPanelViewModel = new RightPanelViewModel(_authenticator, _apihelper);

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

        }

        private void SettingsViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SettingsViewModel))
            {
                CanExecuteChanged?.Invoke(this, e);
            }
        }

    }
}
