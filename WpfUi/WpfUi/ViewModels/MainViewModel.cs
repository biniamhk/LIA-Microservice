using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfUi.Commands;
using WpfUi.Models;
using WpfUi.State.Authenticators;
using WpfUi.State.Navigators;
using WpfUi.ViewModels.Factories;

namespace WpfUi.ViewModels
{
    public class MainViewModel : ViewModelBase
    {


        private readonly IViewModelFactory _viewModelFactory;
        public INavigator Navigator { get; set; }
        public IAuthenticator Authenticator { get; }
        public ICommand UpdateCurrentViewModelCommand { get; }
        public ICommand LogoutCommand { get; }
        public MainViewModel(INavigator navigator, IViewModelFactory viewModelFactory, IAuthenticator authenticator)
        {
            Navigator = navigator;
            _viewModelFactory = viewModelFactory;
            Authenticator = authenticator;
            LogoutCommand = new LogoutCommand(Authenticator, Navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);

        }


    }
}
