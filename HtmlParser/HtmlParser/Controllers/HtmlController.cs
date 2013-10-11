using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace HtmlParser.Controllers
{
    public class HtmlController : ApiController
    {
        [HttpGet]
        [ActionName("get")]
        public string GetHtml(string url)
        {
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            var html = client.DownloadString(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            StringBuilder sb = new StringBuilder();
            var articleContainer = doc.GetElementbyId("text");
            foreach (var tag in articleContainer.ChildNodes)
            {
                if (tag.OriginalName == "p")
                {
                    sb.Append(tag.OuterHtml);
                }

                if (tag.OriginalName == "div" && tag.Id == "ArticleClickBanner")
                {
                    break;
                }
            }

            return sb.ToString();
        }
    }
}
