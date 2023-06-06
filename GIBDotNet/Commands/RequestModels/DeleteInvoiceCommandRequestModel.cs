using GIBDotNet.Commands.ResponseModels;
using System.Collections.Generic;

namespace GIBDotNet.Commands.RequestModels
{
    public class DeleteInvoiceCommandRequestModel
    {
        public string Token { get; private set; }
        public List<GetInvoiceItem> Invoices { get; private set; }
        public string Cause { get; private set; }

        public DeleteInvoiceCommandRequestModel()
        {
            Invoices = new List<GetInvoiceItem>();
        }

        public DeleteInvoiceCommandRequestModel(string token,List<GetInvoiceItem> invoices, string cause)
        {
            Token = token;
            Invoices = invoices;
            Cause = cause;
        }
    }
}
