using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcGIS_ServiceCallingWrapper
{
    class Deleter
    {

        /// <summary>
        /// Sends a delete features request to the GSEC feature service for the given layer index and token.
        /// </summary>
        /// <param name="projectsIds">Projects ids to be used in the where clause.</param>
        /// <param name="lyrId">Layer index</param>
        /// <param name="token">Token</param>
        private void DeleteGeometries(string[] projectsIds, int lyrId, string token)
        {
            using (var client = new HttpClient())
            {
                string ids = "'" + projectsIds[0] + "'";
                for (int i = 1; i < projectsIds.Length; i++)
                    ids += ",'" + projectsIds[i] + "'";

                string qlyrUrl = this.GSECFeatureURL + "/" + lyrId + "/deleteFeatures";

                Dictionary<string, string> data = new Dictionary<string, string>
                                        {
                                            {"objectIds",""},
                                            {"where", ProjectIdFieldName +" in("+ids+")"},
                                            {"geometry","" },{"geometryType","esriGeometryEnvelope"},
                                            {"inSR","" },{"spatialRel","esriSpatialRelIntersects"},
                                            {"gdbVersion","" },{"rollbackOnFailure","true"},{"token",token},
                                            {"f","pjson" }
                                        };

                CustomFormUrlEncodedContent content = new CustomFormUrlEncodedContent(data);

                var response = client.PostAsync(qlyrUrl, content).Result;
                string jsonResult = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode != HttpStatusCode.OK || jsonResult.Contains("error"))
                {
                    logger.Log(Modules.DataLoader, Issues.Error,
                       $"Deleting Old geometries of {currentEntity.EntityName} has the following error: {JsonConvert.SerializeObject(jsonResult)}",
                        Priority.Critical);
                }
            }
        }
    }
}
