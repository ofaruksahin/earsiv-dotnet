using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using GIBDotNet.Commands.GIBRequestModels;
using GIBDotNet.Commands.GIBResponseModels;
using GIBDotNet.Commands.RequestModels;
using GIBDotNet.Commands.ResponseModels;
using GIBDotNet.Contracts;

namespace GIBDotNet.Commands
{
    public class GetInvoicesByDateRangeCommand : BaseGIBCommand, IGIBCommand<GetInvoicesByDateRangeCommandRequestModel, GetInvoicesByDateRangeCommandResponseModel>
    {
        public async Task<BaseGIBResponse<GetInvoicesByDateRangeCommandResponseModel>> DispatchCommand(GetInvoicesByDateRangeCommandRequestModel requestModel)
        {
            var responseModel = new BaseGIBResponse<GetInvoicesByDateRangeCommandResponseModel>();
            try
            {
                MakeCommand("earsiv-services/dispatch");
                AddReferer($"index.jsp?token={requestModel.Token}&v=1685997258289");
                var cmd = CommandConstants.GetCommandTitle(typeof(GetInvoicesByDateRangeCommand));
                var callId = Guid.NewGuid().ToString().Substring(0, 15);
                var pageName = CommandConstants.GetPageTitle(typeof(GetInvoicesByDateRangeCommand));
                var gibRequestModel = new GetInvoicesGIBRequestModel(requestModel);
                var gibRequestModelSerialized = JsonSerializer.Serialize(gibRequestModel);
                var gibRequestModelEncoded = System.Web.HttpUtility.UrlEncode(gibRequestModelSerialized);
                var body = $"cmd={cmd}&callid={callId}&pageName={pageName}&token={requestModel.Token}&jp={gibRequestModelEncoded}";
                AddParameter(body);
                var restResponse = await ExecuteCommand();

                if (!ValidateResponse(restResponse, out GetInvoicesGIBResponseModel gibResponse, out responseModel))
                    return responseModel;

                responseModel.Success(new GetInvoicesByDateRangeCommandResponseModel(gibResponse));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                responseModel.Fail();
            }
            return responseModel;
        }
    }
}

