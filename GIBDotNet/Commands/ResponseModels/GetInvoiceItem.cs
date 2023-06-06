using System;
using static GIBDotNet.Commands.GIBResponseModels.GetInvoiceGIBResponse;
using System.Globalization;
using GIBDotNet.Commands.GIBResponseModels;

namespace GIBDotNet.Commands.ResponseModels
{
    public class GetInvoiceItem
    {
        public string DocumentId { get; private set; }
        public string VKN { get; private set; }
        public string NameSurname { get; private set; }
        public DateTime Date { get; private set; }
        public string DocumentType { get; private set; }
        public string ApproveStatus { get; private set; }
        public string Ettn { get; private set; }

        public GetInvoiceItem()
        {
        }

        public GetInvoiceItem(GetInvoiceGIBResponse gibResponse)
        {
            DocumentId = gibResponse.DocumentId;
            VKN = gibResponse.VKN;
            NameSurname = gibResponse.NameSurname;
            Date = DateTime.ParseExact(gibResponse.Date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DocumentType = gibResponse.DocumentType;
            ApproveStatus = gibResponse.ApproveStatus;
            Ettn = gibResponse.Ettn;
        }
    }
}

