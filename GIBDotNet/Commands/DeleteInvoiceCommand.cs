using GIBDotNet.Commands.GIBRequestModels;
using GIBDotNet.Commands.GIBResponseModels;
using GIBDotNet.Commands.RequestModels;
using GIBDotNet.Commands.ResponseModels;
using GIBDotNet.Contracts;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;

namespace GIBDotNet.Commands
{
    public class DeleteInvoiceCommand : BaseGIBCommand, IGIBCommand<DeleteInvoiceCommandRequestModel, DeleteInvoiceCommandResponseModel>
    {
        public async Task<BaseGIBResponse<DeleteInvoiceCommandResponseModel>> DispatchCommand(DeleteInvoiceCommandRequestModel requestModel)
        {
            var responseModel = new BaseGIBResponse<DeleteInvoiceCommandResponseModel>();
            try
            {
                MakeCommand("earsiv-services/dispatch");
                AddReferer($"index.jsp?token={requestModel.Token}&v=1686079476807");
                var cmd = CommandConstants.GetCommandTitle(typeof(DeleteInvoiceCommand));
                var callId = Guid.NewGuid().ToString().Substring(0, 15);
                var pageName = CommandConstants.GetPageTitle(typeof(DeleteInvoiceCommand));
                var gibRequestModel = new DeleteInvoiceGIBRequestModel(requestModel.Cause,requestModel.Invoices);
                var gibRequestModelSerialized = JsonSerializer.Serialize(gibRequestModel);
                var gibRequestModelEncoded = System.Web.HttpUtility.UrlEncode(gibRequestModelSerialized);
                var body = $"cmd={cmd}&callid={callId}&pageName={pageName}&token={requestModel.Token}&jp={gibRequestModelEncoded}";
                AddParameter(body);
                var restResponse = await ExecuteCommand();

                if (!ValidateResponse(restResponse, out DeleteInvoiceGIBResponseModel gibResponse, out responseModel))
                    return responseModel;

                responseModel.Success(new DeleteInvoiceCommandResponseModel());
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
