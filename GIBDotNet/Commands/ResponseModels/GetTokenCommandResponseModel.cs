using GIBDotNet.Commands.GIBResponseModels;

namespace GIBDotNet.Commands.ResponseModels
{
    public class GetTokenCommandResponseModel
    {
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
