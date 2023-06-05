namespace GIBDotNet.Commands.RequestModels
{
    public class DownloadHTMLCommandRequestModel
    {
        public string Token { get; private set; }
        public string Ettn { get; private set; }

        public DownloadHTMLCommandRequestModel()
        {
        }

        public DownloadHTMLCommandRequestModel(string token, string ettn)
        {
            Token = token;
            Ettn = ettn;
        }
    }
}