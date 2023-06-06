namespace GIBDotNet.Commands.RequestModels
{
    public class SendVerifySMSCommandRequestModel
    {
        public string UserId { get; private set; }
        public string Token { get; private set; }

        public SendVerifySMSCommandRequestModel()
        {
        }

        public SendVerifySMSCommandRequestModel(string userId,string token)
        {
            UserId = userId;
            Token = token;
        }
    }
}
