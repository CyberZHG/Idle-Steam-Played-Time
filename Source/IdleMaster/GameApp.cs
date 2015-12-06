using Newtonsoft.Json;

namespace IdleMaster
{
    public class GameApp
    {
        [JsonProperty("appid")]
        public int AppId { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("logo")]
        public string Logo { get; set; }
        
        [JsonProperty("availStatLinks")]
        public dynamic AvailStatLinks { get; set; }

        [JsonProperty("friendlyURL")]
        public dynamic FriendlyURL { get; set; }

        [JsonProperty("hours")]
        public double Hours { get; set; }

        [JsonProperty("hours_forever")]
        public double HoursForever { get; set; }

        [JsonProperty("last_played")]
        public long LastPlayed { get; set; }

        [JsonProperty("client_summary")]
        public dynamic ClientSummary { get; set; }
    }
}
