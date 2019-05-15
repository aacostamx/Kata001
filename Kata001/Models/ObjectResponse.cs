using Newtonsoft.Json;

namespace Kata001.Models
{
    public class ObjectResponse
    {
        [JsonProperty(PropertyName = "temp")]
        public int Temp { get; set; }

    }
}
