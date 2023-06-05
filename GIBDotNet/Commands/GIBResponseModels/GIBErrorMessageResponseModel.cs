using System.Text.Json.Serialization;

namespace GIBDotNet.Commands.GIBResponseModels
{
    public class GIBErrorMessageResponseModel
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}