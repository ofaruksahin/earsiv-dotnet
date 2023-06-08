namespace GIBDotNet.Commands.RequestModels
{
    public class SendVerifySMSCommandRequestModel
    {
        public string Token { get; private set; }

        public SendVerifySMSCommandRequestModel()
        {
        }

        public SendVerifySMSCommandRequestModel(string token)
        {
            Token = token;
        }
    }
}
