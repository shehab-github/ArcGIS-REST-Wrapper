# ArcGIS-REST-Wrapper
 Wrappers for calling ArcGIS server services using .Net.

You can use it as follow in your .Net code.


            QueryTask queryTask = new QueryTask("https://sampleserver6.arcgisonline.com/arcgis/rest/services/Census/MapServer/1");
            Query query = new Query
            {
                Where = "OBJECTID = 4",
                ResultFormat = Format.json
            };
   

            var result = queryTask.Execute(query);
            
