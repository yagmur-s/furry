using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using FoodService.Model;
using Newtonsoft.Json.Linq;

namespace FoodService
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
         
        [WebMethod]
        public string GetVenue(string latitude, string longitude)
        {
            String jsonData;
            List<VenueModel> venueList = new List<VenueModel>();
            List<VenueModel> venueJsonList = new List<VenueModel>();

            string clientID = ConfigurationSettings.AppSettings["client_id"];
            string clientSecret = ConfigurationSettings.AppSettings["client_secret"];
            string currentDate = DateTime.Now.ToString("yyyyMMdd").ToString();

            using (var client = new WebClient())
            {
                //jsonData = client.DownloadString("https://api.foursquare.com/v2/venues/search?v=&ll=38.42%2C27.13&intent=browse&radius=800&categoryId=4d4b7105d754a06374d81259&client_id=TOMWFBM0IH5Y3XQLE1L41JY22H5OIQO0DKUURDQ5JOKKK4Q3&client_secret=HCGTEWHVFD35NS5ABIKGI3FAXOUCGPUMC5Z0MSVCOYBBBKNX");
                jsonData = client.DownloadString("https://api.foursquare.com/v2/venues/search?v="+ currentDate + "&ll="+ latitude + ","+ longitude + "&intent=browse&radius=800&categoryId=4d4b7105d754a06374d81259&client_id="+ clientID + "&client_secret="+ clientSecret);
            }

            //dynamic responseData = JObject.Parse(jsonData);

            JObject responseData = JObject.Parse(jsonData);
            var secondElement = responseData["response"];
            var venuesElement = secondElement["venues"];
            int VenuesCount = venuesElement.Count();



            for (int i = 0; i < VenuesCount; i++)
            {
                VenueModel vm = new VenueModel();
                //vm.venueId = venuesElement[""]


            }


            return jsonData;
        }
    }
}
