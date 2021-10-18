using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfUi.Commands;
using WpfUi.Models;
using WpfUi.ViewModels;
using WpfUi.ViewModels.Factories;

namespace WpfUi.State.Navigators
{
    public class Navigator : ObservableObject ,INavigator
    {

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {

            get
            {
                return _currentViewModel;
            }

            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }

        }

        private ViewModelBase _seconderyViewModel;
        public ViewModelBase SeconderyViewModel
        {

            get
            {
                return _seconderyViewModel;
            }

            set
            {
                _seconderyViewModel = value;
                OnPropertyChanged(nameof(SeconderyViewModel));
            }

        }

        private ViewModelBase _navigatorViewModel;
        public ViewModelBase NavigatorViewModel
        {
            get 
            {
                return _navigatorViewModel;
            }
            set 
            {
                _navigatorViewModel = value;
                OnPropertyChanged(nameof(NavigatorViewModel));
            }
        }

        private ViewModelBase _rightPanelViewModel;
        public ViewModelBase RightPanelViewModel
        {
            get
            {
                return _rightPanelViewModel;
            }
            set
            {
                _rightPanelViewModel = value;
                OnPropertyChanged(nameof(RightPanelViewModel));
            }
        }


        private ViewModelBase _modalViewModel;
        public ViewModelBase ModalViewModel
        {
            get
            {
                return _modalViewModel;
            }
            set
            {
                _modalViewModel = value;
                OnPropertyChanged(nameof(ModalViewModel));
            }
        }

        private bool _isModalOpen;

        public bool IsModalOpen
        {
            get 
            { return _isModalOpen; 
            }
            set 
            {
                _isModalOpen = value;
                OnPropertyChanged(nameof(IsModalOpen));
            }
        }


        public void CloseModal()
        {
            ModalViewModel = null;
        }

    }
}
