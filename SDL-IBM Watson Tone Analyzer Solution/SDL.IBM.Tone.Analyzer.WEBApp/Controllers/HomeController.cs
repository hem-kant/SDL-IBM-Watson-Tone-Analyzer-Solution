using HtmlAgilityPack;
using IBM.WatsonDeveloperCloud.ToneAnalyzer.v3.Model;
using SDL.IBM.Tone.Analyzing.Helper;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace SDL.IBM.Tone.Analyzer.WEBApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string q)
        {
            List<ToneAnalysis> data = new List<ToneAnalysis>();
            if (!string.IsNullOrEmpty(q))
            {
                var html = new HtmlDocument();
                string htmlString = string.Empty;
                List<string> content = new List<string>();
                html.LoadHtml(new WebClient().DownloadString(q));
                var root = html.DocumentNode;

                var Heading = root.Descendants("h1");
                foreach (var item in Heading)
                {

                    string htmlTagPattern = "<.*?>";
                    htmlString = item.OuterHtml;
                    var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    htmlString = regexCss.Replace(htmlString, string.Empty);
                    htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
                    htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
                    htmlString = htmlString.Replace("&nbsp;", string.Empty);

                    content.Add(htmlString);
                }

                var SubHeading = root.Descendants("h2");
                foreach (var item1 in SubHeading)
                {
                    string htmlTagPattern = "<.*?>";
                    htmlString = item1.OuterHtml;
                    var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    htmlString = regexCss.Replace(htmlString, string.Empty);
                    htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
                    htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
                    htmlString = htmlString.Replace("&nbsp;", string.Empty);

                    content.Add(htmlString);
                }


                var MinorHeadings = root.Descendants("h3");

                foreach (var MinorHeading in MinorHeadings)
                {
                    string htmlTagPattern = "<.*?>";
                    htmlString = MinorHeading.OuterHtml;
                    var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    htmlString = regexCss.Replace(htmlString, string.Empty);
                    htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
                    htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
                    htmlString = htmlString.Replace("&nbsp;", string.Empty);
                    content.Add(htmlString);
                }


                var Paras = root.Descendants("p");
                foreach (var Para in Paras)
                {
                    string htmlTagPattern = "<.*?>";
                    htmlString = Para.OuterHtml;
                    var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    htmlString = regexCss.Replace(htmlString, string.Empty);
                    htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
                    htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
                    htmlString = htmlString.Replace("&nbsp;", string.Empty);

                    content.Add(htmlString);
                }
                data = Analyzing.Analyzing.response(content);
            }
           
            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Custom(string customText)
        {
            List<ToneAnalysis> finalData = new List<ToneAnalysis>();
            if (!string.IsNullOrEmpty(customText))
            {

                ToneAnalysis data = WatsonToneAnalyzerHelper.PostDataAndGetResponse(customText, "539f5087-eae9-4cab-bf67-0c8902c7a163", "PjCjY8PqfaXs");
                finalData.Add(data);
            }           

            return View(finalData);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}