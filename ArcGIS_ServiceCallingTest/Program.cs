using ArcGIS_ServiceCallingWrapper;
using Newtonsoft.Json;
using System;


namespace ArcGIS_ServiceCallingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryTask queryTask = new QueryTask("https://sampleserver6.arcgisonline.com/arcgis/rest/services/Census/MapServer/3");
            Query query = new Query
            {
                Where = "OBJECTID = 10",
                ResultFormat = Format.json
            };

            var result = queryTask.Execute(query);

            Console.WriteLine(result);

            Console.ReadKey();

        }

    }
}
