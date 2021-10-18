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

namespace WpfUi.ViewModels
{
    public class TimePlanerViewModel : ViewModelBase
    {
        private readonly IApiHelper _apihelper;
        private readonly IAuthenticator _authenticator;
        private readonly IViewModelFactory _viewModelfactory;
        private readonly INavigator _navigator;
        public ICommand NewTimePlanCommand { get; set; }
        public ICommand DeleteTimePlanCommand { get; set; }
        public ICommand EditTimePlanCommand { get; set; }


        public TimePlanerViewModel(IApiHelper apihelper, IAuthenticator authenticator,
            IViewModelFactory viewModelfactory, INavigator navigator)
        {
            _apihelper = apihelper;
            _navigator = navigator;
            _authenticator = authenticator;
            _viewModelfactory = viewModelfactory;
            EditTimePlanCommand = new EditTimePlanCommand(_navigator, _viewModelfactory, _authenticator, _apihelper);
            NewTimePlanCommand = new NewTimePlanCommand(_navigator, _viewModelfactory, _authenticator, _apihelper);
            DeleteTimePlanCommand = new DeleteTimePlanCommand(_apihelper, _navigator, _viewModelfactory, _authenticator);

            _ = LoadUserPlansByUserId();
        }


        private List<TimePlanModel> _timeplanlist;
        public List<TimePlanModel> TimeplanList
        {
            get { return _timeplanlist; }
            set
            {
                _timeplanlist = value;
                OnPropertyChanged(nameof(TimeplanList));
            }

        }

        private async Task LoadUserPlansByUserId()
        {
            if (_authenticator != null)
            {
                if (_authenticator.CurrentUser != null)
                {
                    TimeplanList = new List<TimePlanModel>();

                    TimeplanList = await _apihelper.GetAllPlansByUserId(_authenticator.CurrentUser.Id);
                }
            }
        }

    }
}
