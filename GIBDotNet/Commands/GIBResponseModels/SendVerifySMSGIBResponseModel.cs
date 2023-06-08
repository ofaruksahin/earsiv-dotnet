using System.Text.Json.Serialization;

namespace GIBDotNet.Commands.GIBResponseModels
{
    public class SendVerifySMSGIBResponseModel
    {
        public class SendVerifySMSGIBStep1ResponseModel : BaseGIBResponseModel
        {
            [JsonPropertyName("data")]
            public PhoneData Phone { get; set; }

            [JsonPropertyName("")]
            public MetaDataItem MetaData { get; set; }

            public class PhoneData
            {
                [JsonPropertyName("telefon")]
                public string PhoneNumber { get; set; }
            }

            public class MetaDataItem
            {
                [JsonPropertyName("optime")]
                public string Optime { get; set; }
            }
        }

        public class SendVerifySMSGIBStep2ResponseModel : BaseGIBResponseModel
        {
        }

        public class SendVerifySMSGIBStep3ResponseModel : BaseGIBResponseModel
        {
            [JsonPropertyName("data")]
            public OidItem Oid { get; set; }
            [JsonPropertyName("metadata")]
            public MetaDataItem MetaData { get; set; }

            public class OidItem
            {
                [JsonPropertyName("oid")]
                public string Oid { get; set; }
            }

            public class MetaDataItem
            {
                [JsonPropertyName("optime")]
                public string Optime { get; set; }
            }
        }
    }
}

