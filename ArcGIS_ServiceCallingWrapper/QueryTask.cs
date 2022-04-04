using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArcGIS_ServiceCallingWrapper.Helpers
{
    public class QueryTask
    {
        private readonly string serviceUrl;

        /// <summary>
        /// Creates an instance of the QueryTask class usnig the given URL.
        /// </summary>
        /// <param name="url">Feature service URL</param>
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
        /// <param name="query">Query object.</param>
        /// <returns>JSON response of the query task. Check remarks for details.</returns>
        /// <remarks>For more details on the response, you may check "https://developers.arcgis.com/rest/services-reference/enterprise/query-map-service-layer-.htm#:~:text=object%20without%20geometry%0A%7D-,JSON%20Response%20examples,-The%20examples%20below"</remarks>
        public string Execute(Query query)
        {
            string jsonResult = null;

            if (query.Content is null)
                query.BuildQuery();

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(this.serviceUrl + "/query", query.Content).Result;

                jsonResult = response.Content.ReadAsStringAsync().Result;
            }

            return jsonResult;
        }

        /// <summary>
        /// Performs the query task with the given query object in asynchronous mode.
        /// </summary>
        /// <param name="query">Query object.</param>
        /// <returns>Task that contains the JSON response of the query task. Check remarks for details.</returns>
        /// <remarks>For more details on the response, you may check "https://developers.arcgis.com/rest/services-reference/enterprise/query-map-service-layer-.htm#:~:text=object%20without%20geometry%0A%7D-,JSON%20Response%20examples,-The%20examples%20below"</remarks>
        public async Task<string> ExecuteAsync(Query query)
        {
            string jsonResult = null;

            if (query.Content is null)
                query.BuildQuery();

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(this.serviceUrl + "/query", query.Content).Result;

                jsonResult = await response.Content.ReadAsStringAsync();
            }

            return jsonResult;
        }

    }
}
