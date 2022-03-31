using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System;

namespace ArcGIS_ServiceCallingWrapper.Helpers
{
    public class QueryTask
    {
        private readonly string serviceUrl;

        public QueryTask(string url)
        {
            this.serviceUrl = url;
        }

        /// <summary>
        /// Loads the service info in json format.
        /// </summary>
        /// <returns></returns>
        public string LoadInfo()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs the query task with the given query object.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public string Execute(Query query)
        {
            string jsonResult = null;

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(this.serviceUrl + "/query", query.Content).Result;

                jsonResult = response.Content.ReadAsStringAsync().Result;
            }

            return jsonResult;
        }

    }
}
