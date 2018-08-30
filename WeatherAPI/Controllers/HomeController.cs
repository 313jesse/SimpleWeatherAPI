using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.IO;

namespace WeatherAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpWebRequest apiRequest = WebRequest.CreateHttp("https://forecast.weather.gov/MapClick.php?lat=42.331429&lon=-83.045753&FcstType=json");
            

            apiRequest.UserAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";

            HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse();

            if (apiResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader ResponseData = new StreamReader(apiResponse.GetResponseStream());

                string data = ResponseData.ReadToEnd();

                //for (int i = 0; i <= 12; i++)
                //{              

                JObject jsonData = JObject.Parse(data);
                ViewBag.DataTemperature = jsonData["data"]["temperature"];
                ViewBag.DataWeather = jsonData["data"]["weather"];

                ViewBag.data = data;
            }

            

                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}