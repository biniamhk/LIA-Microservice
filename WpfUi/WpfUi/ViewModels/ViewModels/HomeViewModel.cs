using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUi.Helpers;
using WpfUi.State.Authenticators;
using WpfUi.State.Navigators;

namespace WpfUi.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly INavigator _navigator;
        private AuthenticatedUser _whoisUser;

        public HomeViewModel(IAuthenticator authenticator, INavigator navigator)
        {
            _authenticator = authenticator;
            _navigator = navigator;
            WhoisUser = _authenticator.CurrentUser;
        }

        public AuthenticatedUser WhoisUser
        {
            get { return _whoisUser; }
            set
            {
                _whoisUser = value;
                OnPropertyChanged(nameof(WhoisUser));
            }
        }























    }
}
