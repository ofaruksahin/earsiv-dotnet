namespace GIBDotNet.Commands.ResponseModels
{
    public class SendVerifySMSCommandResponseModel
    {
        public string Oid { get; private set; }

        public SendVerifySMSCommandResponseModel()
        {
        }

        public SendVerifySMSCommandResponseModel(string oid)
        {
            Oid = oid;
        }
    }
}
