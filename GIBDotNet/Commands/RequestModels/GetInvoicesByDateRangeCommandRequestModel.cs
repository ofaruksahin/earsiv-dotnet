using System;

namespace GIBDotNet.Commands.RequestModels
{
    public class GetInvoicesByDateRangeCommandRequestModel
    {
        public string Token { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public GetInvoicesByDateRangeCommandRequestModel()
        {
        }

        public GetInvoicesByDateRangeCommandRequestModel(string token,DateTime startDate, DateTime endDate)
        {
            Token = token;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}

