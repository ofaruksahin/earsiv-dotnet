using GIBDotNet.Commands.GIBResponseModels;
using GIBDotNet.Commands.RequestModels;
using GIBDotNet.Commands.ResponseModels;
using GIBDotNet.Contracts;
using GIBDotNet.Options;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GIBDotNet.Commands
{
    /// <summary>
    /// GIB tarafında oturum açmak için kullanılır
    /// </summary>
    public class GetTokenCommand : BaseGIBCommand, IGIBCommand<GetTokenCommandRequestModel, GetTokenCommandResponseModel>
    {
        public async Task<BaseGIBResponse<GetTokenCommandResponseModel>> DispatchCommand(GetTokenCommandRequestModel requestModel)
        {
            var responseModel = new BaseGIBResponse<GetTokenCommandResponseModel>();

            try
            {
                MakeCommand("earsiv-services/assos-login");
                AddReferer("intragiris.html");
                if (GIBOptions.IsProduction)
                    AddParameter("assoscmd", "anologin");
                else
                    AddParameter("assoscmd", "login");
                AddParameter("rtype", "json");
                AddParameter("userid", requestModel.UserId);
                AddParameter("sifre", requestModel.Password);
                AddParameter("sifre2", requestModel.Password);
                AddParameter("parola", "1");
                var restResponse = await ExecuteCommand();

                if (!ValidateResponse(restResponse, out GetTokenGIBResponseModel gibResponse, out responseModel))
                    return responseModel;

                responseModel.Success(new GetTokenCommandResponseModel(gibResponse));
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