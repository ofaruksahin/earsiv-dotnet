using GIBDotNet.Commands.GIBResponseModels;
using GIBDotNet.Commands.RequestModels;
using GIBDotNet.Commands.ResponseModels;
using GIBDotNet.Contracts;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GIBDotNet.Commands
{
    /// <summary>
    /// GIB tarafında açılan oturumu sonlandırmak için kullanılır
    /// </summary>
    public class LogoutCommand : BaseGIBCommand, IGIBCommand<LogoutCommandRequestModel, LogoutCommandResponseModel>
    {
        public async Task<BaseGIBResponse<LogoutCommandResponseModel>> DispatchCommand(LogoutCommandRequestModel requestModel)
        {
            var responseModel = new BaseGIBResponse<LogoutCommandResponseModel>();
            try
            {
                MakeCommand("earsiv-services/assos-login");
                AddReferer("intragiris.html");
                AddParameter("assoscmd", "logout");
                AddParameter("rtype", "json");
                AddParameter("token", requestModel.Token);
                var restResponse = await ExecuteCommand();

                if (!ValidateResponse(restResponse, out LogoutGIBResponseModel gibResponse, out responseModel))
                    return responseModel;

                responseModel.Success(new LogoutCommandResponseModel());
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