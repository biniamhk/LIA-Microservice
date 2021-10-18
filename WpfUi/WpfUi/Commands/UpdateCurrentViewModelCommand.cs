using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfUi.Helpers;
using WpfUi.State.Navigators;
using WpfUi.ViewModels;
using WpfUi.ViewModels.Factories;

namespace WpfUi.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {

        private readonly INavigator _navigator;
        private readonly IViewModelFactory _ViewModelFactory;



       // AuthenticatedUser? User { get; set; }

        public UpdateCurrentViewModelCommand(INavigator navigator, IViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _ViewModelFactory = viewModelFactory;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;


                _navigator.CurrentViewModel = _ViewModelFactory.CreateViewModel(viewType);
                _navigator.SeconderyViewModel = _ViewModelFactory.CreateViewModel(ViewType.Timeplanner);
            }
        }
    }
}
