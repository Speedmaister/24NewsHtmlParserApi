using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace HtmlParser.Controllers
{
    public class WeatherController : ApiController
    {
        [HttpGet]
        [ActionName("get")]
        public string GetWeather(string url)
        {
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            var json = client.DownloadString(url);
            return json;
        }
    }
}
