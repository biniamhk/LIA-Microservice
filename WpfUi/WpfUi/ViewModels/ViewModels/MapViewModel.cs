using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Security;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks;
using Esri.ArcGISRuntime.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfUi.Commands;
using WpfUi.Helpers;
using WpfUi.Models;

namespace WpfUi.ViewModels
{
    public class MapViewModel : ViewModelBase
    {

        private readonly IApiHelper _apihelper;
        public ICommand MapSearchCommand { get; set; }

        public MapViewModel(IApiHelper apihelper)
        {
            _apihelper = apihelper;
            MapSearchCommand = new MapSearchCommand(apihelper, this);
        }



        private Map _mymap = new Map(BasemapType.Streets, 59.3293, 18.0686, 10);
        public Map MyMap
        {
            get => _mymap;
            set { _mymap = value; OnPropertyChanged(nameof(MyMap)); }
        }

        private string _searchString = "Search";
        public string SearchString
        {
            get
            {
                return _searchString;
            }

            set
            {
                _searchString = value;
                OnPropertyChanged(nameof(SearchString));

            }
        }



        private List<MapSearchModel> _mapsearch;
        public List<MapSearchModel> MapSearch
        {
            get
            {
                return _mapsearch;
            }

            set
            {
                _mapsearch = value;
                OnPropertyChanged(nameof(MapSearch));
                MapLocation();
            }
        }


        private void MapLocation()
        {
            var MapLocation = MapSearch.FirstOrDefault();

            MyMap = new Map(BasemapType.Streets, MapLocation.LocationInfo.Latitude, MapLocation.LocationInfo.Longitude, 12);
        }


    }
}
