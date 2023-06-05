using System;
using System.Collections.Generic;

namespace GIBDotNet.Commands.RequestModels
{
    public class CreateDraftInvoiceRequestModel
    {
        public string Token { get; set; }
        public string Ettn { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string VKN { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TaxOffice { get; set; }
        public string Address { get; set; }
        public double SubTotal { get; set; }
        public double Tax { get; set; }
        public int Piece { get; set; }

        public List<CreateDraftInvoiceItemRequestModel> Items { get; private set; }

        public CreateDraftInvoiceRequestModel()
        {
            Items = new List<CreateDraftInvoiceItemRequestModel>();
        }

        public void AddItem(CreateDraftInvoiceItemRequestModel item)
        {
            Items.Add(item);
        }

        public class CreateDraftInvoiceItemRequestModel
        {
            public string Name { get; set; }
            public int Piece { get; set; }
            public double SubTotal { get; set; }
            public double Tax { get; set; }
        }
    }
}