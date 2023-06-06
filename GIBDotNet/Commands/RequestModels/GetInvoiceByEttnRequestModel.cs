using System;

namespace GIBDotNet.Commands.RequestModels
{
    public class GetInvoiceByEttnRequestModel
    {
        public string Token { get;private set; }
        public string Ettn { get; private set; }
        public DateTime StartDate { get;private set; }
        public DateTime EndDate { get;private set; }

        public GetInvoiceByEttnRequestModel()
        {
        }

        public GetInvoiceByEttnRequestModel(string token, string ettn,DateTime startDate,DateTime endDate)
        {
            Token = token;
            Ettn = ettn;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
