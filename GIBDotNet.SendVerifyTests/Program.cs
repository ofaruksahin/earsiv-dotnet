using GIBDotNet.Contracts;
using GIBDotNet.Implementations;
using GIBDotNet.Options;

namespace GIBDotNet.SendVerifyTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = string.Empty;
            string password = string.Empty;

            Console.WriteLine("GIB UserName:");
            userName = Console.ReadLine();

            Console.WriteLine("GIB Password:");
            password = Console.ReadLine();

            GIBOptions.EnableProductionMode();
            IGIBService gibService = new GIBService();
            var tokenResponse = gibService.GetToken(userName, password).GetAwaiter().GetResult();
            if (!tokenResponse.IsSuccess) return;

            var startDate = DateTime.Now.AddDays(-1);
            var endDate = DateTime.Now;

            var invoices = gibService.GetInvoiceByDateRange(tokenResponse.Data.Token, startDate, endDate).GetAwaiter().GetResult();
            if (!invoices.IsSuccess) return;

            foreach (var item in invoices.Data.Invoices)
            {
                Console.WriteLine(item.Ettn);
            }

            string ettn = string.Empty;
            Console.WriteLine("Ettn:");
            ettn = Console.ReadLine();

            var oidResult = gibService.SendVerifySms(tokenResponse.Data.Token).GetAwaiter().GetResult();

            Console.ReadKey();
        }
    }
}