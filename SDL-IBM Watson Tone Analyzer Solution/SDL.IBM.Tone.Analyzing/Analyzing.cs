using HtmlAgilityPack;
using IBM.WatsonDeveloperCloud.ToneAnalyzer.v3;
using IBM.WatsonDeveloperCloud.ToneAnalyzer.v3.Model;
using SDL.IBM.Tone.Analyzing.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace SDL.IBM.Tone.Analyzing
{
    public class Analyzing
    {

        public static List<ToneAnalysis> response(List<string> text)
        {
            List<ToneAnalysis> finalData = new List<ToneAnalysis>();

            foreach (var item in text)
            {

                if (!string.IsNullOrEmpty(item))
                {
                    var regexCss = new Regex(@"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    var finalItem = regexCss.Replace(item, string.Empty);
                    var newString = string.Join(" ", Regex.Split(finalItem, @"(?:\r\n|\n|\r|\t)"));
                    StringBuilder sb = new StringBuilder();
                    char[] longChars = newString.ToCharArray();

                    int spaceCount = 0;

                    //Using standard method with no library help
                    for (int i = 0; i < longChars.Length; i++)
                    {
                        //If space then keep a count and move on until nonspace char is found
                        if (longChars[i] == 32)
                        {
                            spaceCount++;
                            continue;
                        }

                        //If more than one space then append a single space  
                        if (spaceCount > 1 && sb.Length > 0)
                            sb.Append(" ");

                        //Append the non space character
                        sb.Append(longChars[i]);

                        //Reset the space count
                        spaceCount = 1;
                    }

                    ToneAnalysis data = WatsonToneAnalyzerHelper.PostDataAndGetResponse(sb.ToString(), "539f5087-eae9-4cab-bf67-0c8902c7a163", "PjCjY8PqfaXs");
                    finalData.Add(data);
                }

            }
            return finalData;
        }
    }
}
