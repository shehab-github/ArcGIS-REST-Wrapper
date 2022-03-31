using GSECBE;
using GSECBS;
using Newtonsoft.Json;
using System;

namespace GSECDataLoaderServiceTestApp.JsonConverters
{
    public class JsonNullIntConverter : JsonConverter
    {
        private EventLogService eventLogService = new EventLogService ();

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int) || objectType == typeof(int?);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {

                return null;
            }

            return int.Parse(reader.Value.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
