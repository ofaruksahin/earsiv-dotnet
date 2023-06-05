namespace GIBDotNet.Commands.ResponseModels
{
    public class DownloadHTMLCommandResponseModel
    {
        /// <summary>
        /// İlgili faturaya ait xml ve html dosyasının zip halini byte olarak tutar.
        /// </summary>
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