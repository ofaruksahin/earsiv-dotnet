using System;
using System.Globalization;
using GIBDotNet.Commands.GIBResponseModels;
using static GIBDotNet.Commands.GIBResponseModels.GetInvoicesGIBResponseModel;

namespace GIBDotNet.Commands.ResponseModels
{
    public class GetInvoiceByEttnResponseModel : GetInvoiceItem
    {
        public GetInvoiceByEttnResponseModel()
        {
        }

        public GetInvoiceByEttnResponseModel(GetInvoiceGIBResponse gibResponse) : base(gibResponse)
        {
        }
    }
}
