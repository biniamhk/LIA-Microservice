using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfUi.Helpers;
using WpfUi.ViewModels;

namespace WpfUi.Commands
{
    public class MapSearchCommand : ICommand
    {

        private readonly IApiHelper _apiHelper;
        private  readonly MapViewModel _mapViewModel;

        public MapSearchCommand(IApiHelper apiHelper, MapViewModel mapViewModel)
        {
            _apiHelper = apiHelper;
            _mapViewModel = mapViewModel;
            _mapViewModel.PropertyChanged += SettingsViewModel_PropertyChanged;
        }




        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {

            try
            {
                _mapViewModel.MapSearch = await _apiHelper.MapSearch(_mapViewModel.SearchString);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }



        }


        private void SettingsViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MapViewModel))
            {
                CanExecuteChanged?.Invoke(this, e);
            }
        }


    }
}
