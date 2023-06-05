using GIBDotNet.Commands;
using GIBDotNet.Commands.RequestModels;
using GIBDotNet.Commands.ResponseModels;
using GIBDotNet.Contracts;
using System.Threading.Tasks;

namespace GIBDotNet.Implementations
{
    public class GIBService : IGIBService
    {
        private readonly IGIBCommandDispatcher _commandDispatcher;

        public GIBService()
        {
            _commandDispatcher = new GIBCommandDispatcher();
        }

        public Task<BaseGIBResponse<GetTokenCommandResponseModel>> GetToken(string userId, string password)
        {
            var requestModel = GetTokenCommandRequestModel.Create(userId, password);
            return _commandDispatcher.Dispatch(new GetTokenCommand(), requestModel);
        }

        public Task<BaseGIBResponse<LogoutCommandResponseModel>> Logout(string token)
        {
            var requestModel = LogoutCommandRequestModel.Create(token);
            return _commandDispatcher.Dispatch(new LogoutCommand(), requestModel);
        }

        public Task<BaseGIBResponse<CreateDraftInvoiceCommandResponseModel>> CreateDraftInvoice(CreateDraftInvoiceRequestModel invoice)
        {
            return _commandDispatcher.Dispatch(new CreateDraftInvoiceCommand(), invoice);
        }
    }
}
