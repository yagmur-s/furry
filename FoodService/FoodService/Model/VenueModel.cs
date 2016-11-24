using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodService.Model
{
    public class VenueModel
    {

        public string venueId { get; set; }
        public string venueName { get; set; }
        public string address { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public int distance { get; set; }
        public List<string> formattedAddress { get; set; }
        public string categoryId { get; set; }
        public string catagoryName { get; set; }
        public string url { get; set; }
    }
}