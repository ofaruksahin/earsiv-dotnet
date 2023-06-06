using GIBDotNet.Commands.RequestModels;
using System.Text.Json.Serialization;

namespace GIBDotNet.Commands.GIBRequestModels
{
    public class GetInvoiceByEttnGIBRequestModel
    {
        [JsonPropertyName("baslangic")]
        public string StartDate { get; private set; }
        [JsonPropertyName("bitis")]
        public string EndDate { get; private set; }
        [JsonPropertyName("hangiTip")]
        public string Type { get; private set; }

        public GetInvoiceByEttnGIBRequestModel(GetInvoiceByEttnRequestModel requestModel)
        {
            StartDate = requestModel.StartDate.ToString("dd/MM/yyyy");
            EndDate = requestModel.EndDate.ToString("dd/MM/yyyy");
            Type = "Buyuk";
        }
    }
}
