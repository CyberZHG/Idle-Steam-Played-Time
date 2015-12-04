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
        public StatLinks AvailStatLinks { get; set; }

        [JsonProperty("friendlyURL")]
        public dynamic FriendlyURL { get; set; }

        [JsonProperty("client_summary")]
        public ClientSummary ClientSummary { get; set; }
    }

    public class StatLinks
    {
        [JsonProperty("achievements")]
        public bool Achievements { get; set; }

        [JsonProperty("global_achievements")]
        public bool GlobalAchievements { get; set; }

        [JsonProperty("stats")]
        public bool Stats { get; set; }

        [JsonProperty("leaderboards")]
        public bool Leaderboarders { get; set; }

        [JsonProperty("global_leaderboards")]
        public bool GlobalLeaderboards { get; set; }
    }

    public class ClientSummary
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("localContentSize")]
        public string LocalContentSize { get; set; }
    }

}
