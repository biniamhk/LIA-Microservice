using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfUi.State.Navigators;

namespace WpfUi.Commands
{
    public class CloseModalCommand : ICommand
    {

        private readonly INavigator _navigator;

        public CloseModalCommand(INavigator navigator)
        {
            _navigator = navigator;
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
                _navigator.CloseModal();
                _navigator.IsModalOpen = false;

            }
        }
    }
}
