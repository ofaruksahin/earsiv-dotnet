using System;
using System.Collections.Generic;
using System.Linq;
using GIBDotNet.Commands.GIBResponseModels;

namespace GIBDotNet.Commands.ResponseModels
{
    public class GetInvoicesByDateRangeCommandResponseModel
    {
        public List<GetInvoiceItem> Invoices { get; set; }

        public GetInvoicesByDateRangeCommandResponseModel()
        {
            Invoices = new List<GetInvoiceItem>();
        }

        public GetInvoicesByDateRangeCommandResponseModel(GetInvoicesGIBResponseModel responseModel)
        {
            Invoices = responseModel.Data.Select(f => new GetInvoiceItem(f)).ToList();
        }
    }
}

