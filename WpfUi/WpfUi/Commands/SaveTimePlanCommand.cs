﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfUi.Helpers;
using WpfUi.Models;
using WpfUi.State.Authenticators;
using WpfUi.State.Navigators;
using WpfUi.ViewModels;
using WpfUi.ViewModels.Factories;

namespace WpfUi.Commands
{
    public class SaveTimePlanCommand : ICommand
    {
        private readonly IApiHelper _apihelper;
        private readonly INavigator _navigator;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IAuthenticator _authenticator;

        public SaveTimePlanCommand(IApiHelper apihelper, INavigator navigator, IViewModelFactory viewModelFactory, IAuthenticator authenticator)
        {
            _apihelper = apihelper;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                TimePlanModel timePlan = parameter as TimePlanModel;
                if (timePlan != null)
                {
                    try
                    {
                        _ = await _apihelper.CreateTimePlan(timePlan);

                    }
                    catch (Exception e)
                    {

                        MessageBox.Show(e.Message);
                    }

                    _navigator.SeconderyViewModel = new TimePlanerViewModel(_apihelper, _authenticator, _viewModelFactory, _navigator);
                    _navigator.IsModalOpen = false;
                    _navigator.CloseModal();
                }

            }
        }
    }
}
