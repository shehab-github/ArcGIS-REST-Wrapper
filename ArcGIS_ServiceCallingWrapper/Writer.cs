using ArcGIS_ServiceCallingWrapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcGIS_ServiceCallingWrapper
{
    public class Writer
    {

        /// <summary>
        /// Last addresults of points;
        /// </summary>
        private AddResult[] pointsResult;
        /// <summary>
        /// Last addresults of lines.
        /// </summary>
        private AddResult[] linesResult;
        /// <summary>
        /// Last addresult of polygons.
        /// </summary>
        private AddResult[] polygonsResult;



        /// <summary>
        /// Writes the given data of the entity to GSEC database.
        /// </summary>
        private void WriteData(IEnumerable<PointFeature> points, IEnumerable<LineFeature> lines, IEnumerable<PolygonFeature> polygons, IEnumerable<TableFeature> projectsDetails)
        {
            if (points == null || lines == null || polygons == null || projectsDetails == null)
                return;

            if (WriteEntityData(points.ToArray(), lines.ToArray(), polygons.ToArray(), projectsDetails.ToArray()))
            {
                this.lastInserted = null;
                this.pointsResult = this.linesResult = this.polygonsResult = null;

                logger.Log(Modules.DataLoader, Issues.Information, $"Projects of {this.currentEntity.EntityName} has its data written to gsec database successfully.", Priority.Message);
            }
            else
            {
                Undo();
                logger.Log(Modules.DataLoader, Issues.Error, $"Projects of {this.currentEntity.EntityName} failed to be written.", Priority.Message);
            }
        }


        /// <summary>
        /// Writes the given data to the gsec feature service of the given layer id.
        /// </summary>
        /// <param name="data">Data to post.</param>
        /// <param name="lyrId">Layer id in the service.</param>
        private bool WriteToLayer(string data, int lyrId, out AddResult[] results, out string msg)
        {
            msg = null;
            bool isSuccessful = false;
            results = null;

            if (String.IsNullOrWhiteSpace(data) || lyrId < 0)
                return false;

            using (var client = new HttpClient())
            {
                string token = GenerateToken(this.GSECFeatureURL, this.userName, this.password);

                Dictionary<string, string> values = new Dictionary<string, string>
                                        {
                                           {"features", data },
                                           {"gdbVersion",""},
                                           {"rollbackOnFailure","true"},
                                           {"token",token},
                                           {"f","pjson"}
                                        };

                CustomFormUrlEncodedContent content = new CustomFormUrlEncodedContent(values);


                string url = GSECFeatureURL + "/" + lyrId + "/addFeatures";

                HttpResponseMessage response = client.PostAsync(url, content).Result;
                string jsonResp = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == HttpStatusCode.OK && !jsonResp.Contains("error"))
                {
                    JObject jObj = JObject.Parse(jsonResp);

                    results = JsonConvert.DeserializeObject<AddResult[]>(jObj["addResults"].ToString());

                    isSuccessful = true;
                }
                else
                {
                    msg = jsonResp;
                    isSuccessful = false;
                }
            }
            return isSuccessful;
        }


        /// <summary>
        /// Undo adding the given features.
        /// </summary>
        /// <param name="resultsObj"></param>
        /// <param name="lyrId">id of the layer in the gsec feature serivce to be undone</param>
        private bool UndoLayer(AddResult[] resultsObj, int lyrId, out string msg)
        {
            msg = null;
            bool isDeleted = false;
            if (resultsObj == null)
                return false;

            string token = GenerateToken(GSECFeatureURL, this.userName, this.password);

            string objectdIds = null;

            for (int i = 0; i < resultsObj.Length; i++)
                objectdIds += resultsObj[i].objectId.ToString() + ",";

            objectdIds = objectdIds.TrimEnd(',');

            using (var client = new HttpClient())
            {
                Dictionary<string, string> values = new Dictionary<string, string>
                                        {
                                           {"objectIds",objectdIds},
                                           {"where",""},
                                           {"geometry",""},
                                           {"geometryType","esriGeometryEnvelope"},
                                           {"inSR",""},
                                           {"spatialRel","esriSpatialRelIntersects"},
                                           {"gdbVersion",""},
                                           {"rollbackOnFailure","true"},
                                           {"f","pjson"},
                                           {"token",token}
                                        };

                CustomFormUrlEncodedContent content = new CustomFormUrlEncodedContent(values);

                string url = GSECFeatureURL + "/" + lyrId + "/deleteFeatures";

                HttpResponseMessage response = client.PostAsync(url, content).Result;
                string responseMSG = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == HttpStatusCode.OK && !responseMSG.Contains("error"))
                    isDeleted = true;
                else
                    msg = JsonConvert.SerializeObject(responseMSG);
            }
            return isDeleted;
        }

    }

}
