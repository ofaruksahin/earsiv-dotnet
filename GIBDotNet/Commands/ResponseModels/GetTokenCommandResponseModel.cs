using GIBDotNet.Commands.GIBResponseModels;

namespace GIBDotNet.Commands.ResponseModels
{
    public class GetTokenCommandResponseModel
    {
        /// <summary>
        /// Eğer oturum açma işlemi başarılıysa oluşturulan token bilgisini tutar
        /// </summary>
        public string Token { get; private set; }

        public GetTokenCommandResponseModel()
        {
        }

        public GetTokenCommandResponseModel(GetTokenGIBResponseModel gibResponseModel)
        {
            Token = gibResponseModel.Token;
        }
    }
}