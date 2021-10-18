using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfUi.Helpers;
using WpfUi.State.Authenticators;
using WpfUi.State.Navigators;
using WpfUi.ViewModels;
using WpfUi.ViewModels.Factories;

namespace WpfUi.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly IAuthenticator _authenticator;
        private readonly LoginViewModel _loginViewModel;
        private readonly IRenavigator _renavigator;
        private readonly IApiHelper _apiHelper;
        private readonly INavigator _navigator;
        private readonly IViewModelFactory _viewModelFactory;

        public event EventHandler CanExecuteChanged;

        public LoginCommand(IAuthenticator authenticator, LoginViewModel loginViewModel,
            IRenavigator renavigator, IApiHelper apiHelper, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            _authenticator = authenticator;
            _loginViewModel = loginViewModel;
            _renavigator = renavigator;
            _apiHelper = apiHelper;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            bool success = await _authenticator.Login(_loginViewModel.Username, parameter.ToString());
            if (success)
            {
                if (CanExecute(parameter))
                {
                    _renavigator.Renavigate();
                    _navigator.SeconderyViewModel = new TimePlanerViewModel(_apiHelper, _authenticator, _viewModelFactory, _navigator);
                    _navigator.NavigatorViewModel = new NavigationBarViewModel(_navigator, _viewModelFactory, _authenticator, _apiHelper);
                    _navigator.RightPanelViewModel = new RightPanelViewModel(_authenticator, _apiHelper);
                }
            }
        }
    }
}
