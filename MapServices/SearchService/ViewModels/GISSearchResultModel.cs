using System.Collections.Generic;

namespace SearchService.ViewModels
{
    public class GISSearchResultModel
    {
        public SpatialReference spatialReference { get; set; }
        public List<Candidate> candidates { get; set; }
        public class SpatialReference
        {
            public int wkid { get; set; }
            public int latestWkid { get; set; }
        }

        public class Location
        {
            public double x { get; set; }
            public double y { get; set; }
        }

        public class Attributes
        {
            public string PlaceName { get; set; }
            public string Place_addr { get; set; }
        }

        public class Extent
        {
            public double xmin { get; set; }
            public double ymin { get; set; }
            public double xmax { get; set; }
            public double ymax { get; set; }
        }

        public class Candidate
        {
            public string address { get; set; }
            public Location location { get; set; }
            public int score { get; set; }
            public Attributes attributes { get; set; }
            public Extent extent { get; set; }
        }


    }
}
