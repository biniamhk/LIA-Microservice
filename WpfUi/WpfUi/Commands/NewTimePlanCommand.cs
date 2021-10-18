using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfUi.Helpers;
using WpfUi.Models;
using WpfUi.State.Authenticators;
using WpfUi.State.Navigators;
using WpfUi.ViewModels;
using WpfUi.ViewModels.Factories;
using WpfUi.ViewModels.ModalViewModels;

namespace WpfUi.Commands
{
    public class NewTimePlanCommand : ICommand
    {


        private readonly INavigator _navigator;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IAuthenticator _authenticator;
        private readonly IApiHelper _apiHelper;


        public NewTimePlanCommand(INavigator navigator, IViewModelFactory viewModelFactory, IAuthenticator authenticator, IApiHelper apiHelper)
        {

            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;
            _apiHelper = apiHelper;
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

                _navigator.ModalViewModel = new CreateTimePlanModaViewModel(_navigator, _authenticator, _apiHelper, _viewModelFactory);
                _navigator.IsModalOpen = true;

            }
        }
    }
}
