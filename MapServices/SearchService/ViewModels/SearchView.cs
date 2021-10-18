using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchService.ViewModels
{
    public class SearchView
    {
        public string Place { get; set; }
        public string PlaceAddress { get; set; }
        public Location LocationInfo { get; set; }

        public class Location
        {
            public double Longitude { get; set; }
            public double Latitude { get; set; }
        }
    }
}
