using ArcGIS_ServiceCallingWrapper.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace ArcGIS_ServiceCallingWrapper
{
    public class Query
    {
        public CustomFormUrlEncodedContent Content { get; private set; }

        /// <summary>
        /// Creates an instance with all defaults.
        /// </summary>
        public Query()
        {

        }

        /// <summary>
        /// Create an instance of the query object using the given params.
        /// </summary>
        /// <param name="queryParams">key value pair of the params. For more info check remarks.</param>
        /// <remarks>For details about the query params, you can check "https://developers.arcgis.com/rest/services-reference/enterprise/query-map-service-layer-.htm#:~:text=parameters%20table%20below.-,Request%20parameters,-Parameter"</remarks>
        public Query(IEnumerable<KeyValuePair<string, string>> queryParams)
        {
            Content = new CustomFormUrlEncodedContent(queryParams);
        }

        internal void BuildQuery()
        {
            string orderByFields = OrderByFields?.Aggregate((a, b) => a + "," + b) ?? "";
            string groupByStats = GroupByFieldsForStatistics?.Aggregate((a, b) => a + "," + b) ?? "";


            var data = new Dictionary<string, string>
                   {
                      {"where",Where},{"text",Text},{"objectIds",ObjectIds},{"time",Time},{"geometry",Geometry},
                      {"geometryType",GeometryType.ToString()},{"inSR",InSR},{"spatialRel",SpatialRel.ToString()},
                      {"relationParam" ,RelationParam},{"outFields",OutFields},{"returnGeometry",ReturnGeometry.ToString()},
                      {"returnTrueCurves",ReturnTrueCurves.ToString()},{"maxAllowableOffset",MaxAllowableOffset},
                      {"geometryPrecision",GeometryPrecision},
                      {"outSR",OutSR} ,{"returnIdsOnly",ReturnIdsOnly.ToString()},{"returnCountOnly",ReturnCountOnly.ToString()},
                      {"orderByFields",orderByFields},{"groupByFieldsForStatistics", groupByStats},{"outStatistics", OutStatistics},
                      {"returnZ",  "FALSE"},{"returnM",ReturnM.ToString()},{"gdbVersion",GdbVersion},
                      {"returnDistinctValues",ReturnDistinctValues.ToString()},{"resultOffset", ResultOffset} ,
                      {"resultRecordCount",ResultRecordCount},{"f",ResultFormat.ToString()},{"token",Token}
                   };
            Content = new CustomFormUrlEncodedContent(data);
        }

        public string Where { get; set; } = "";


        public Format ResultFormat { get; set; } = Format.json;


        public string OutFields { get; set; } = "*";


        public string Text { get; set; } = "";


        public string ObjectIds { get; set; } = "";


        public string Time { get; set; } = "";


        public string Geometry { get; set; } = "";


        public EsriGeometryType GeometryType { get; set; } = EsriGeometryType.esriGeometryEnvelope;



        public string EsriGeometryEnvelope { get; set; } = "";


        public string InSR { get; set; } = "";


        public EsriSpatialRel SpatialRel { get; set; } = EsriSpatialRel.esriSpatialRelIntersects;


        public string RelationParam { get; set; } = "";


        public string GdbVersion { get; set; } = "";


        public string ResultOffset { get; set; } = "";


        public string Token { get; set; } = "";


        public string OutStatistics { get; set; } = "";

        public string[] OrderByFields { get; set; }
        public string[] GroupByFieldsForStatistics { get; set; }



        public bool ReturnGeometry { get; set; } = true;

        public bool ReturnTrueCurves { get; set; }

        public bool ReturnIdsOnly { get; set; }
        public bool ReturnCountOnly { get; set; }
        public bool ReturnZ { get; set; }
        public bool ReturnM { get; set; }
        public bool ReturnDistinctValues { get; set; }


        public string MaxAllowableOffset { get; set; } = "";

        public string GeometryPrecision { get; set; } = "";

        public string OutSR { get; set; } = "";

        public string ResultRecordCount { get; set; } = "";

    }

    public enum Format
    {
        html,
        json
    }

    public enum EsriSpatialRel
    {
        esriSpatialRelIntersects,
        esriSpatialRelContains,
        esriSpatialRelCrosses,
        esriSpatialRelEnvelopeIntersects,
        esriSpatialRelIndexIntersects,
        esriSpatialRelOverlaps,
        esriSpatialRelTouches,
        esriSpatialRelWithin,
        esriSpatialRelRelation
    }

    public enum EsriGeometryType
    {
        esriGeometryPoint,
        esriGeometryMultipoint,
        esriGeometryPolyline,
        esriGeometryPolygon,
        esriGeometryEnvelope
    }


}
