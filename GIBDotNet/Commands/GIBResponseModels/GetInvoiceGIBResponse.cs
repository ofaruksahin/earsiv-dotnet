using System;
using System.Text.Json.Serialization;

namespace GIBDotNet.Commands.GIBResponseModels
{
    public class GetInvoiceGIBResponse
    {
        [JsonPropertyName("belgeNumarasi")]
        public string DocumentId { get; set; }
        [JsonPropertyName("aliciVknTckn")]
        public string VKN { get; set; }
        [JsonPropertyName("aliciUnvanAdSoyad")]
        public string NameSurname { get; set; }
        [JsonPropertyName("belgeTarihi")]
        public string Date { get; set; }
        [JsonPropertyName("belgeTuru")]
        public string DocumentType { get; set; }
        [JsonPropertyName("onayDurumu")]
        public string ApproveStatus { get; set; }
        [JsonPropertyName("ettn")]
        public string Ettn { get; set; }
    }
}

