using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfUi.State.Authenticators;
using WpfUi.State.Navigators;
using WpfUi.ViewModels;
using WpfUi.ViewModels.Factories;

namespace WpfUi.Commands
{
    public class LogoutCommand : ICommand
    {

        private IAuthenticator _authenticator;
        private INavigator _navigator;
        private IViewModelFactory _viewModelFactory;

        public LogoutCommand(IAuthenticator authenticator, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            _authenticator = authenticator;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            
            if (CanExecute(parameter))
            {
               
                _authenticator.IsLoggedIn = false;
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(ViewType.Login);

            }


        }
    }



}

