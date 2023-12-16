#nullable disable
using ExcepitionMidLib.Common;
using Newtonsoft.Json;

namespace ExcepitionMidLib.Models
{
    public class HttpActionResponce
    {
        [JsonProperty(Constants.JsonKey_Responce_TrackingId)]
        public string TrackingId { get; set; }

        [JsonProperty(Constants.JsonKey_Responce_UserMessage)]
        public string UserMessage { get; set; }

        [JsonProperty(Constants.JsonKey_Responce_DeveloperMessage)]
        public string DeveloperMessage { get; set; }

        [JsonProperty(Constants.JsonKey_Responce_Data)]
        public object Data { get; set; }

        [JsonProperty(Constants.JsonKey_Responce_StatusCode)]
        public int StatusCode { get; set; }

    }
}
