# ArcGIS-REST-Wrapper
 Wrappers for calling ArcGIS server services using .Net.

You can use it as follow in your .Net code.


            QueryTask queryTask = new QueryTask("");
            Query query = new Query
            {
                Where = "OBJECTID = 4",
                ResultFormat = Format.json
            };
   

            var result = queryTask.Execute(query);
            
