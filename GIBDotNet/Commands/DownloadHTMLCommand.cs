using GIBDotNet.Commands.RequestModels;
using GIBDotNet.Commands.ResponseModels;
using GIBDotNet.Contracts;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GIBDotNet.Commands
{
    /// <summary>
    /// Oluşturulan faturayı zip olarak indirmek için kullanılır
    /// </summary>
    public class DownloadHTMLCommand : BaseGIBCommand, IGIBCommand<DownloadHTMLCommandRequestModel, DownloadHTMLCommandResponseModel>
    {
        public async Task<BaseGIBResponse<DownloadHTMLCommandResponseModel>> DispatchCommand(DownloadHTMLCommandRequestModel requestModel)
        {
            var responseModel = new BaseGIBResponse<DownloadHTMLCommandResponseModel>();
            try
            {
                var docType = "FATURA";
                var approveType = System.Web.HttpUtility.UrlEncode("Onaylandı");
                var cmd = CommandConstants.GetCommandTitle(typeof(DownloadHTMLCommand));

                MakeCommand($"earsiv-services/download?token={requestModel.Token}&ettn={requestModel.Ettn}&belgeTip={docType}&onayDurumu={approveType}&cmd={cmd}");
                AddReferer($"index.jsp?token={requestModel.Token}&v=1624464892887");
                var buffer = await DownloadData();
                responseModel.Success(new DownloadHTMLCommandResponseModel(buffer));
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                responseModel.Fail();
            }

            return responseModel;
        }
    }
}