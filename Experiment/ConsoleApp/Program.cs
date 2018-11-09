using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ConsoleApp
{
    class Program
    {
        private static int balance = 0, maxBet = 100000, gains = 0, losses = 0;
        private static Random random = new Random();

        static void Main(string[] args)
        {
        }
    }

    [Newtonsoft.Json.JsonConverter(typeof(BaseValueConverter))]
    public class Model
    {
        public IBaseValue Value;
        public string DataType;
    }

    public interface IBaseValue
    {
        TimeSpan ValueAsTimeSpan();
    }
    
    public class TimeSpanValue : IBaseValue
    {
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds{ get; set; }

        public TimeSpan ValueAsTimeSpan()
        {
            return new TimeSpan(Days, Hours, Minutes, Seconds);
        }
    }

    public class BaseValueConverter : JsonConverter
    {
        public override bool CanWrite
        {
            get { return false; }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IBaseValue).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var objValue = JObject.Load(reader);
            if (objValue != null)
            {
                var value = objValue["Value"];
                if (value != null)
                {
                    switch (value.Type)
                    {
                        case JTokenType.String:
                            // Time spans are recognized as strings.
                            if (objectType == typeof(TimeSpanValue))
                            {
                                return TimeSpan.Parse(value.ToString());
                            }

                            return null;

                        case JTokenType.TimeSpan:
                            // This code is never reached
                            var timeSpan = value;
                            return new TimeSpanValue();
                    }
                }
            }

            return null;
        }
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}