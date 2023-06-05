using GIBDotNet.Commands.GIBRequestModels;
using GIBDotNet.Commands.GIBResponseModels;
using GIBDotNet.Commands.RequestModels;
using GIBDotNet.Commands.ResponseModels;
using GIBDotNet.Contracts;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GIBDotNet.Commands
{
    public class CreateDraftInvoiceCommand : BaseGIBCommand, IGIBCommand<CreateDraftInvoiceRequestModel, CreateDraftInvoiceCommandResponseModel>
    {
        public async Task<BaseGIBResponse<CreateDraftInvoiceCommandResponseModel>> DispatchCommand(CreateDraftInvoiceRequestModel requestModel)
        {
            var responseModel = new BaseGIBResponse<CreateDraftInvoiceCommandResponseModel>();
            try
            {
                MakeCommand("earsiv-services/dispatch");
                AddReferer($"index.jsp?token={requestModel.Token}&v=1624476996318");

                var gibRequestModel = new CreateDraftInvoiceGIBRequestModel(requestModel);
                var callId = Guid.NewGuid().ToString().Substring(0, 15);
                var cmd = CommandConstants.GetCommandTitle(typeof(CreateDraftInvoiceCommand));
                var pageName = CommandConstants.GetCommandTitle(typeof(CreateDraftInvoiceCommand));
                var urlEncodedData = System.Web.HttpUtility.UrlEncode(gibRequestModel.Invoice);
                AddParameter($"cmd={cmd}&callid={callId}&pageName={pageName}&token={requestModel.Token}&jp={urlEncodedData}");
                var restResponse = await ExecuteCommand();

                if (!ValidateResponse(restResponse, out CreateDraftInvoiceGIBResponseModel gibResponse, out responseModel))
                    return responseModel;

                responseModel.Success(new CreateDraftInvoiceCommandResponseModel());
                return responseModel;
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