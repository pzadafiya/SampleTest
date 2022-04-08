using Newtonsoft.Json;

namespace SampleTest.Models
{
	public class IPInfoResponse
	{
        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("loc")]
        public string Loc { get; set; }

        [JsonProperty("org")]
        public string Org { get; set; }

        [JsonProperty("postal")]
        public long Postal { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
