using System.Text.Json.Serialization;

namespace GIBDotNet.Commands.GIBResponseModels
{
    public class LogoutGIBResponseModel : BaseGIBResponseModel
    {
        [JsonPropertyName("data")]
        public LogoutRedirectUrl Data { get; set; }

        public class LogoutRedirectUrl
        {
            [JsonPropertyName("redirectUrl")]
            public string RedirectUrl { get; set; }
        }

        public LogoutGIBResponseModel()
        {
            Data = new LogoutRedirectUrl();
        }
    }
}