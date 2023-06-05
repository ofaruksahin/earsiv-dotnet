namespace GIBDotNet.Commands.RequestModels
{
    public class LogoutCommandRequestModel
    {
        public string Token { get; set; }

        public static LogoutCommandRequestModel Create(string token)
        {
            return new LogoutCommandRequestModel
            {
                Token = token
            };
        }
    }
}