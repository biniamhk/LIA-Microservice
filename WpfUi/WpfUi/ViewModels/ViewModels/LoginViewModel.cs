using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfUi.Commands;
using WpfUi.Helpers;
using WpfUi.State.Authenticators;
using WpfUi.State.Navigators;
using WpfUi.ViewModels.Factories;

namespace WpfUi.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        public LoginViewModel(IAuthenticator authenicator, IRenavigator renavigator, INavigator navigator, IApiHelper apiHelper, IViewModelFactory viewModelFactory)
        {
            LoginCommand = new LoginCommand(authenicator, this, renavigator, apiHelper ,navigator, viewModelFactory);
        }

        private string _username = "Email";
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));

            }
        }

        public ICommand LoginCommand { get; }


    }
}
