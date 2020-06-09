using Newtonsoft.Json;

namespace google_honyaku.Model.JsonObjects
{   
    [JsonObject]
    /// <summary>
    /// 翻訳APIからのレスポンスのjson形式を表す 
    /// </summary>
    class TrancelateAPIJsonObject
    {
        [JsonProperty("code")]
        public int code { get; set; }
        [JsonProperty("text")]
        public string text { get; set; }

    }
    
}
