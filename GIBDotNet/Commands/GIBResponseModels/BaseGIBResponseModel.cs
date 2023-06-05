using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GIBDotNet.Commands.GIBResponseModels
{
    public abstract class BaseGIBResponseModel
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("messages")]
        public List<GIBErrorMessageResponseModel> Messages { get; set; }

        public BaseGIBResponseModel()
        {
            Messages = new List<GIBErrorMessageResponseModel>();
        }
    }
}