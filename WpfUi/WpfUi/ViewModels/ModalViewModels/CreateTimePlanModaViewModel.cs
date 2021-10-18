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
    public class CreateTimePlanModaViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;
        private readonly IApiHelper _apiHelper;
        private readonly IViewModelFactory _viewModelFactory;
    
        public ICommand CloseModalCommand { get; set; }
        public ICommand SaveTimePlanCommand { get; set; }
       



        public CreateTimePlanModaViewModel(INavigator navigator, IAuthenticator authenticator, IApiHelper apiHelper, IViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _apiHelper = apiHelper;
            _authenticator = authenticator;
            _viewModelFactory = viewModelFactory;
            CloseModalCommand = new CloseModalCommand(_navigator);
            SaveTimePlanCommand = new SaveTimePlanCommand(_apiHelper, _navigator , _viewModelFactory , _authenticator);
            

            Timeplan = new TimePlanModel();
            Timeplan.CreatedBy = _authenticator.CurrentUser.Id;
            Timeplan.LastUpdated = DateTime.Now;
            Timeplan.FromDate = DateTime.Now;
            Timeplan.ToDate = DateTime.Now.AddDays(1);
        }

        private TimePlanModel _timeplan;

        public TimePlanModel Timeplan
        {
            get 
            { 
                return _timeplan;
            }
            set
            {

                _timeplan = value;
                OnPropertyChanged(nameof(Timeplan));

            }
        }




    }
}
