using System.Text.Json.Serialization;

namespace GIBDotNet.Commands.GIBResponseModels
{
    public class GetTokenGIBResponseModel : BaseGIBResponseModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("chgpwd")]
        public string Chgpwd { get; set; }

        [JsonPropertyName("redirectUrl")]
        public string RedirectUrl { get; set; }
    }
}
