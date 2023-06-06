using GIBDotNet.Commands.GIBRequestModels;
using GIBDotNet.Commands.GIBResponseModels;
using GIBDotNet.Commands.RequestModels;
using GIBDotNet.Commands.ResponseModels;
using GIBDotNet.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GIBDotNet.Commands
{
    public class GetInvoiceByEttnCommand : BaseGIBCommand, IGIBCommand<GetInvoiceByEttnRequestModel, GetInvoiceByEttnResponseModel>
    {
        public async Task<BaseGIBResponse<GetInvoiceByEttnResponseModel>> DispatchCommand(GetInvoiceByEttnRequestModel requestModel)
        {
            var responseModel = new BaseGIBResponse<GetInvoiceByEttnResponseModel>();
            try
            {
                MakeCommand("earsiv-services/dispatch");
                AddReferer($"index.jsp?token={requestModel.Token}&v=1685997258289");
                var cmd = CommandConstants.GetCommandTitle(typeof(GetInvoiceByEttnCommand));
                var callId = Guid.NewGuid().ToString().Substring(0, 15);
                var pageName = CommandConstants.GetPageTitle(typeof(GetInvoiceByEttnCommand));
                var gibRequestModel = new GetInvoiceByEttnGIBRequestModel(requestModel);
                var gibRequestModelSerialized = JsonSerializer.Serialize(gibRequestModel);
                var gibRequestModelEncoded = System.Web.HttpUtility.UrlEncode(gibRequestModelSerialized);
                var body = $"cmd={cmd}&callid={callId}&pageName={pageName}&token={requestModel.Token}&jp={gibRequestModelEncoded}";
                AddParameter(body);
                var restResponse = await ExecuteCommand();

                if (!ValidateResponse(restResponse, out GetInvoiceByEttnGIBResponseModel gibResponse, out responseModel))
                    return responseModel;

                var invoice = gibResponse.Data.FirstOrDefault(f => f.Ettn == requestModel.Ettn);
                if(invoice == null)
                {
                    responseModel.Fail(new List<string> { "Invoice not found" });
                    return responseModel;
                }

                responseModel.Success(new GetInvoiceByEttnResponseModel(invoice));
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
