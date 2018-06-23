using IBM.WatsonDeveloperCloud.ToneAnalyzer.v3;
using IBM.WatsonDeveloperCloud.ToneAnalyzer.v3.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SDL.IBM.Tone.Analyzing.Helper
{
    public class WatsonToneAnalyzerHelper
    {

        public static ToneAnalysis PostDataAndGetResponse(string input, string userId, string password)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string _Server = string.Format("https://gateway.watsonplatform.net/tone-analyzer/api/v3/tone?version={0}", DateTime.Today.ToString("yyyy-MM-dd"));
            // Get the data to be analyzed for tone
            string postData = "{\"text\": \"" + input + "\"}";

            // Create the web request
            var request = (HttpWebRequest)WebRequest.Create(_Server);

            // Configure the BlueMix credentials
            string auth = string.Format("{0}:{1}", userId, password);
            string auth64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(auth));
            string credentials = string.Format("{0} {1}", "Basic", auth64);

            // Set the web request parameters
            request.Headers[HttpRequestHeader.Authorization] = credentials;
            request.Method = "POST";
            request.Accept = "application/json";
            request.ContentType = "application/json";

            byte[] byteArray = Encoding.UTF8.GetBytes(JsonHelper.FormatJson(postData));
            // Set the ContentLength property of the WebRequest
            request.ContentLength = byteArray.Length;

            // Get the request stream
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);

            // Get the response
            WebResponse response = request.GetResponse();
            // Display the status
            var status = ((HttpWebResponse)response).StatusDescription;
            // Get the stream containing content returned by the service
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access
            StreamReader reader = new StreamReader(dataStream);
            // Read and format the content
            string responseFromServer = reader.ReadToEnd();
            ToneAnalysis toneAnalysisData = new ToneAnalysis();

            toneAnalysisData = JsonConvert.DeserializeObject<ToneAnalysis>(responseFromServer);
            toneAnalysisData.input = input;

            return toneAnalysisData;
        }

    }
}
