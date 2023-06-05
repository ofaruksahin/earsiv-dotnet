using System.Text.Json.Serialization;

namespace GIBDotNet.Commands.GIBResponseModels
{
    public class CreateDraftInvoiceGIBResponseModel : BaseGIBResponseModel
    {
        [JsonPropertyName("data")]
        public string Data { get; set; }

        [JsonPropertyName("metadata")]
        public MetadataResponseModel Metadata { get; set; }

        public class MetadataResponseModel
        {
            [JsonPropertyName("optime")]
            public string Optime { get; set; }
        }
    }
}
