using IBM.WatsonDeveloperCloud.ToneAnalyzer.v3.Model;
using Newtonsoft.Json;
using SDL.IBM.Tone.Analyzing.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace SDL.IBM.Tone.Analyzer.WEBApp.Controllers
{
    public class ToneAnalyzerController : Controller
    {
        public JsonResult getToneAnalyzer(string text)
        {
            List<ToneAnalysis> finalData = new List<ToneAnalysis>();
            if (!string.IsNullOrEmpty(text))
            {

                ToneAnalysis data = WatsonToneAnalyzerHelper.PostDataAndGetResponse(text, "<UID>", "<PWD>");
                finalData.Add(data);

            }
            return Json(finalData, JsonRequestBehavior.AllowGet);
        }
       
    }
}
