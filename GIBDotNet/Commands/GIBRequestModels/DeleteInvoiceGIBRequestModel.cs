using GIBDotNet.Commands.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace GIBDotNet.Commands.GIBRequestModels
{
    public class DeleteInvoiceGIBRequestModel
    {
        [JsonPropertyName("silinecekler")]
        public List<DeleteInvoiceItem> Invoices { get; private set; }
        [JsonPropertyName("aciklama")]
        public string Cause { get; private set; }

        public DeleteInvoiceGIBRequestModel()
        {
            Invoices = new List<DeleteInvoiceItem>();
        }

        public DeleteInvoiceGIBRequestModel(string cause,List<GetInvoiceItem> invoices)
        {
            Invoices = invoices.Select(f => new DeleteInvoiceItem(f)).ToList();
            Cause = cause;
        }

        public class DeleteInvoiceItem
        {
            [JsonPropertyName("faturaOid")]
            public string Oid { get; private set; }
            [JsonPropertyName("toplamTutar")]
            public string Price { get; private set; }
            [JsonPropertyName("belgeNumarasi")]
            public string DocumentId { get; private set; }
            [JsonPropertyName("aliciVknTckn")]
            public string BuyerVKN { get; private set; }
            [JsonPropertyName("aliciUnvanAdSoyad")]
            public string BuyerNameSurname { get; private set; }
            [JsonPropertyName("saticiVknTckn")]
            public string SellerVKN { get; private set; }
            [JsonPropertyName("saticiUnvanAdSoyad")]
            public string SellerNameSurname { get; private set; }
            [JsonPropertyName("belgeTarihi")]
            public string Date { get; private set; }
            [JsonPropertyName("belgeTuru")]
            public string DocumentType { get; private set; } = "FATURA";
            [JsonPropertyName("onayDurumu")]
            public string ApproveStatus { get; private set; }
            [JsonPropertyName("ettn")]
            public string Ettn { get; private set; }
            [JsonPropertyName("talepDurumColumn")]
            public string RequestStatusColumn { get; private set; }
            [JsonPropertyName("iptalItiraz")]
            public string Cancel { get; private set; } = "-99";
            [JsonPropertyName("talepDurum")]
            public string RequestStatus { get; private set; } = "-99";

            public DeleteInvoiceItem()
            {
            }

            public DeleteInvoiceItem(GetInvoiceItem invoiceItem,bool signedInvoice = false)
            {
                Oid = string.Empty;
                Price = "0";
                DocumentId = invoiceItem.DocumentId;
                BuyerVKN = string.Empty;
                BuyerNameSurname = string.Empty;
                if (signedInvoice)
                {
                    BuyerVKN = invoiceItem.VKN;
                    BuyerNameSurname = invoiceItem.NameSurname;
                }
                Date = invoiceItem.Date.ToString("dd-MM-yyyy");
                ApproveStatus = invoiceItem.ApproveStatus;
                Ettn = invoiceItem.Ettn;
                RequestStatusColumn = "----------";
                SellerVKN = string.Empty;
                SellerNameSurname = string.Empty;
            }
        }
    }
}
