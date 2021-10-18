using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfUi.Commands;
using WpfUi.Helpers;
using WpfUi.Models;
using WpfUi.State.Authenticators;
using WpfUi.State.Navigators;
using WpfUi.ViewModels.Factories;

namespace WpfUi.ViewModels.ModalViewModels
{
    public class EditTimePlanViewModel : ViewModelBase
    {

        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;
        private readonly IApiHelper _apiHelper;
        private readonly IViewModelFactory _viewModelFactory;

        public ICommand CloseModalCommand { get; set; }
        public ICommand SaveEditedTimePlanCommand { get; set; }


        public EditTimePlanViewModel(INavigator navigator, IAuthenticator authenticator, IApiHelper apiHelper, IViewModelFactory viewModelFactory, TimePlanModel timePlan)
        {
            _navigator = navigator;
            _authenticator = authenticator;
            _apiHelper = apiHelper;
            _viewModelFactory = viewModelFactory;
            TimePlan = timePlan;
            SaveEditedTimePlanCommand = new SaveEditedTimePlanCommand(_apiHelper,_navigator,_viewModelFactory,_authenticator);
            CloseModalCommand = new CloseModalCommand(_navigator);

        }




        private TimePlanModel _timePlan;
        public TimePlanModel TimePlan
        {
            get { return _timePlan; }
            set
            {
                _timePlan = value;
                OnPropertyChanged(nameof(TimePlan));
            }
        }


    }
}
