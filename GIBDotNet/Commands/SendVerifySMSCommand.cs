using GIBDotNet.Commands.RequestModels;
using GIBDotNet.Commands.ResponseModels;
using GIBDotNet.Contracts;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using static GIBDotNet.Commands.GIBRequestModels.SendVerifySMSGIBRequestModel;
using static GIBDotNet.Commands.GIBResponseModels.SendVerifySMSGIBResponseModel;

namespace GIBDotNet.Commands
{
    public class SendVerifySMSCommand : BaseGIBCommand, IGIBCommand<SendVerifySMSCommandRequestModel, SendVerifySMSCommandResponseModel>
    {
        public async Task<BaseGIBResponse<SendVerifySMSCommandResponseModel>> DispatchCommand(SendVerifySMSCommandRequestModel requestModel)
        {
            var baseResponse = new BaseGIBResponse<SendVerifySMSCommandResponseModel>();
            var step1 = await ExecuteStep1(requestModel);
            if (!step1.IsSuccess) return baseResponse;
            return default;
        }

        private async Task<BaseGIBResponse<SendVerifySMSGIBStep1ResponseModel>> ExecuteStep1(SendVerifySMSCommandRequestModel requestModel)
        {
            var step1RequestModel = new SendVerifySMSGIBStep1RequestModel(requestModel);
            var step1Command = new SendVerifySMSCommandStep1();
            return await step1Command.DispatchCommand(step1RequestModel);
        }

        public class SendVerifySMSCommandStep1 : BaseGIBCommand, IGIBCommand<SendVerifySMSGIBStep1RequestModel, SendVerifySMSGIBStep1ResponseModel>
        {
            public async Task<BaseGIBResponse<SendVerifySMSGIBStep1ResponseModel>> DispatchCommand(SendVerifySMSGIBStep1RequestModel requestModel)
            {
                var responseModel = new BaseGIBResponse<SendVerifySMSGIBStep1ResponseModel>();
                try
                {
                    MakeCommand("earsiv-services/dispatch");
                    AddReferer($"index.jsp?token={requestModel.Token}&v=1686082216818");
                    var cmd = CommandConstants.GetCommandTitle(typeof(SendVerifySMSCommandStep1));
                    var pageName = CommandConstants.GetPageTitle(typeof(SendVerifySMSCommandStep1));
                    var callId = Guid.NewGuid().ToString().Substring(0, 15);
                    var gibRequestSerialized = JsonSerializer.Serialize(new { });
                    var gibRequestEncoded = System.Web.HttpUtility.UrlEncode(gibRequestSerialized);
                    var body = $"cmd={cmd}&callid={callId}&pageName={pageName}&token={requestModel.Token}&jp={gibRequestEncoded}";
                    AddParameter(body);
                    var restResponse = await ExecuteCommand();

                    if (!ValidateResponse(restResponse, out SendVerifySMSGIBStep1ResponseModel gibResponse, out responseModel))
                        return responseModel;

                    responseModel.Success(gibResponse);
                }catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    responseModel.Fail();
                }

                return responseModel;
            }
        }

        public class SendVerifySMSCommandStep2 : BaseGIBCommand, IGIBCommand<SendVerifySMSGIBStep2RequestModel, SendVerifySMSGIBStep2ResponseModel>
        {
            public async Task<BaseGIBResponse<SendVerifySMSGIBStep2ResponseModel>> DispatchCommand(SendVerifySMSGIBStep2RequestModel requestModel)
            {
                var responseModel = new BaseGIBResponse<SendVerifySMSGIBStep2ResponseModel>();
                try
                {
                    MakeCommand("side-dispatch");
                    AddReferer($"index.jsp?token={requestModel.Token}&v=1686082216818");
                    var cmd = CommandConstants.GetCommandTitle(typeof(SendVerifySMSCommandStep2));
                    var pageName = CommandConstants.GetPageTitle(typeof(SendVerifySMSCommandStep2));
                    var callId = Guid.NewGuid().ToString().Substring(0, 15);
                    var pm = "arsiv_portal";
                    var gibRequestSerialized = JsonSerializer.Serialize(requestModel);
                    var gibRequestEncoded = System.Web.HttpUtility.UrlEncode(gibRequestSerialized);
                    var body = $"cmd={cmd}&callid={callId}&pageName={pageName}&pm=arsiv_portal&token={requestModel.Token}&jp={gibRequestEncoded}";
                    AddParameter(body);
                    var restResponse = await ExecuteCommand();

                    if (!ValidateResponse(restResponse, out SendVerifySMSGIBStep2ResponseModel gibResponse, out responseModel))
                        return responseModel;

                    responseModel.Success(new SendVerifySMSGIBStep2ResponseModel());
                }catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    responseModel.Fail();
                }

                return responseModel;
            }
        }

        public class SendVerifySMSCommandStep3 : BaseGIBCommand
        {
        }
    }
}
