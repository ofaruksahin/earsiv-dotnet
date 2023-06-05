namespace GIBDotNet.Commands.ResponseModels
{
    public class DownloadHTMLCommandResponseModel
    {
        public byte[] Data { get; private set; }

        public DownloadHTMLCommandResponseModel()
        {
        }

        public DownloadHTMLCommandResponseModel(byte[] data)
        {
            Data = data;
        }
    }
}