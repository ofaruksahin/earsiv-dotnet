using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GIBDotNet.Commands.GIBResponseModels
{
    public class GetInvoicesGIBResponseModel : BaseGIBResponseModel
    {
        [JsonPropertyName("data")]
        public List<GetInvoiceGIBResponse> Data { get; set; }

        public GetInvoicesGIBResponseModel()
        {
            Data = new List<GetInvoiceGIBResponse>();
        }
    }
}
