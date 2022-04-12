using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace ArcGIS_ServiceCallingWrapper.Helpers
{
    public class Helpers
    {

        /// <summary>
        /// Check if the given url is a valid arcgis map service url and there's a connectivity.
        /// </summary>
        /// <param name="mapURL">Map service url.</param>
        /// <param name="userName">User name of the service if any.</param>
        /// <param name="password">Password of the service if any. Must be sent if sent a user name.</param>
        /// <param name="response">Returns the reponse as json string.</param>
        /// <returns>True for valid map, otherwise false.</returns>
        public static bool IsValidMapserviceURL(string mapURL, string userName, string password, out string response)
        {
            if (Validators.IsUrlValid(mapURL) && mapURL.ToLower().EndsWith("mapserver"))
            {
                string token = GenerateToken(mapURL, userName, password);

                string qURL = token == null ? mapURL + "/layers?f=pjson" : mapURL + "/layers?f=pjson" + "&&token=" + token;

                using (var client = new HttpClient())
                {
                    HttpResponseMessage result = client.GetAsync(qURL).Result;
                    response = result.Content.ReadAsStringAsync().Result;

                    return result.StatusCode == HttpStatusCode.OK && !response.Contains("error");
                }
            }
            else
            {
                response = "URL isn't a valid map service.";
            }
            return false;
        }

        /// <summary>
        /// Generates arcgis token for the given service url using the given username and password.
        /// </summary>
        /// <param name="url">Service url.</param>
        /// <param name="userName">User name</param>
        /// <param name="password">Password.</param>
        /// <param name="validity">Validity time in minutes for the generated token.[Default is 60 minutes]</param>
        /// <param name="client"></param>
        /// <returns>The Token otherwise the error from the ArcGIS server.</returns>
        public static string GenerateToken(string url, string userName, string password, int validity = 60, string client = "requestip")
        {
            string token = null;
            if (String.IsNullOrWhiteSpace(url) || String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(password))
                return null;

            Uri uri = new Uri(url);

            string reqURL = $"{uri.Scheme}://{uri.Host}/{uri.Segments[1]}tokens/generateToken";

            using (HttpClient httpClient = new HttpClient())
            {
                Dictionary<string, string> values = new Dictionary<string, string>
                                        {
                                                {"username",userName},
                                                {"password",password},
                                                {"client",client},
                                                {"referer",""},
                                                {"ip",""},
                                                {"expiration",validity.ToString()},
                                                {"f","json"}
                                        };

                CustomFormUrlEncodedContent content = new CustomFormUrlEncodedContent(values);

                HttpResponseMessage response = httpClient.PostAsync(reqURL, content).Result;
                string jsonResp = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == HttpStatusCode.OK && !jsonResp.Contains("error"))
                {
                    JObject jObj = JObject.Parse(jsonResp);

                    token = jObj["token"]?.ToString();
                }
                else
                {
                    token = "Can't generate token. " + JsonConvert.SerializeObject(jsonResp);

                }
            }
            return token;
        }

        /// <summary>
        /// Convert given json to indented one.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string PrettyJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }
    }
}
