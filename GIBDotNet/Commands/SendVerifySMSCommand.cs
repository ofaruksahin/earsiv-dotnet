using GIBDotNet.Commands.RequestModels;
using GIBDotNet.Commands.ResponseModels;
using GIBDotNet.Contracts;
using System.Threading.Tasks;

namespace GIBDotNet.Commands
{
    public class SendVerifySMSCommand : BaseGIBCommand, IGIBCommand<SendVerifySMSCommandRequestModel, SendVerifySMSCommandResponseModel>
    {
        public async Task<BaseGIBResponse<SendVerifySMSCommandResponseModel>> DispatchCommand(SendVerifySMSCommandRequestModel requestModel)
        {
            return default;
        }

        public class SendVerifySMSCommandStep1 : BaseGIBCommand
        {
        }

        public class SendVerifySMSCommandStep2 : BaseGIBCommand
        {
        }

        public class SendVerifySMSCommandStep3 : BaseGIBCommand
        {
        }
    }
}
