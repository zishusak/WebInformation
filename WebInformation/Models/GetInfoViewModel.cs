using Newtonsoft.Json;

namespace WebInformation.Models
{
    public class GetInfoViewModel
    {
        [JsonProperty("ip")]

        public string IP { get; set; }


        [JsonProperty("city")]

        public string City { get; set; }


        [JsonProperty("region")]

        public string Region { get; set; }


        [JsonProperty("country")]

        public string Country { get; set; }


        [JsonProperty("loc")]

        public string Loc { get; set; }


        [JsonProperty("timezone")]

        public string TimeZone { get; set; }



    }
}
