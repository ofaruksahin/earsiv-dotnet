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
            var step2 = await ExecuteStep2(requestModel,step1.Data.Phone.PhoneNumber);
            if (!step2.IsSuccess) return baseResponse;
            var step3 = await ExecuteStep3(requestModel, step1.Data.Phone.PhoneNumber);
            if (!step3.IsSuccess) return baseResponse;
            baseResponse.Success(new SendVerifySMSCommandResponseModel(step3.Data.Oid.Oid));
            return baseResponse;
        }

        private async Task<BaseGIBResponse<SendVerifySMSGIBStep1ResponseModel>> ExecuteStep1(SendVerifySMSCommandRequestModel requestModel)
        {
            var step1RequestModel = new SendVerifySMSGIBStep1RequestModel(requestModel);
            var step1Command = new SendVerifySMSCommandStep1();
            return await step1Command.DispatchCommand(step1RequestModel);
        }

        private async Task<BaseGIBResponse<SendVerifySMSGIBStep2ResponseModel>> ExecuteStep2(SendVerifySMSCommandRequestModel requestModel,string phoneNumber)
        {
            var step2RequestModel = new SendVerifySMSGIBStep2RequestModel(requestModel.Token, phoneNumber);
            var step2Command = new SendVerifySMSCommandStep2();
            return await step2Command.DispatchCommand(step2RequestModel);
        }

        private async Task<BaseGIBResponse<SendVerifySMSGIBStep3ResponseModel>> ExecuteStep3(SendVerifySMSCommandRequestModel requestModel,string phoneNumber)
        {
            var step3RequestModel = new SendVerifySMSGIBStep3RequestModel(requestModel.Token, phoneNumber);
            var step3Command = new SendVerifySMSCommandStep3();
            return await step3Command.DispatchCommand(step3RequestModel);
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
                    var body = $"cmd={cmd}&callid={callId}&pageName={pageName}&pm={pm}&token={requestModel.Token}&jp={gibRequestEncoded}";
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

        public class SendVerifySMSCommandStep3 : BaseGIBCommand, IGIBCommand<SendVerifySMSGIBStep3RequestModel, SendVerifySMSGIBStep3ResponseModel>
        {
            public async Task<BaseGIBResponse<SendVerifySMSGIBStep3ResponseModel>> DispatchCommand(SendVerifySMSGIBStep3RequestModel requestModel)
            {
                var responseModel = new BaseGIBResponse<SendVerifySMSGIBStep3ResponseModel>();
                try
                {
                    MakeCommand("earsiv-services/dispatch");
                    AddReferer($"index.jsp?token={requestModel.Token}&v=1686082216818");
                    var cmd = CommandConstants.GetCommandTitle(typeof(SendVerifySMSCommandStep3));
                    var pageName = CommandConstants.GetPageTitle(typeof(SendVerifySMSCommandStep3));
                    var callId = Guid.NewGuid().ToString().Substring(0, 15);
                    var gibRequestSerialized = JsonSerializer.Serialize(requestModel);
                    var gibRequestEncoded = System.Web.HttpUtility.UrlEncode(gibRequestSerialized);
                    var body = $"cmd={cmd}&callId={callId}&pageName={pageName}&token={requestModel.Token}&jp={gibRequestEncoded}";
                    AddParameter(body);
                    var restResponse = await ExecuteCommand();

                    if (!ValidateResponse(restResponse, out SendVerifySMSGIBStep3ResponseModel gibResponse, out responseModel))
                        return responseModel;

                    responseModel.Success(gibResponse);
                }catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

                return responseModel;
            }
        }
    }
}
