using GIBDotNet.Commands.RequestModels;
using GIBDotNet.Commands.ResponseModels;
using System.Threading.Tasks;

namespace GIBDotNet.Contracts
{
    public interface IGIBService
    {
        Task<BaseGIBResponse<GetTokenCommandResponseModel>> GetToken(string userId, string password);

        Task<BaseGIBResponse<LogoutCommandResponseModel>> Logout(string token);

        Task<BaseGIBResponse<CreateDraftInvoiceCommandResponseModel>> CreateDraftInvoice(CreateDraftInvoiceRequestModel invoice);

        Task<BaseGIBResponse<DownloadHTMLCommandResponseModel>> DownloadHTML(string token, string ettn);
    }
}