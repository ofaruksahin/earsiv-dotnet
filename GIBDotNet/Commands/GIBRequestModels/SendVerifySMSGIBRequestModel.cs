using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using GIBDotNet.Commands.RequestModels;

namespace GIBDotNet.Commands.GIBRequestModels
{
    public class SendVerifySMSGIBRequestModel
    {
        public class SendVerifySMSGIBStep1RequestModel
        {
            public string Token { get; private set; }

            public SendVerifySMSGIBStep1RequestModel()
            {
            }

            public SendVerifySMSGIBStep1RequestModel(SendVerifySMSCommandRequestModel requestModel)
            {
                Token = requestModel.Token;
            }
        }

        public class SendVerifySMSGIBStep2RequestModel
        {
            [JsonIgnore]
            public string Token { get; private set; }
            [JsonPropertyName("userid")]
            public string UserId { get; private set; }
            [JsonPropertyName("bfnames")]
            public IEnumerable<string> BFNames { get; private set; } = new List<string> { "portal.RG_SMSONAY" };
            [JsonPropertyName("loadedList")]
            public IEnumerable<string> LoadedList { get; private set; } = new List<string>
            {
                "portal.TEST_WELCOME",
                "portal.MAINTREEMENU",
                "portal.RG_BASITTASLAKLAR"
            };
            [JsonPropertyName("params")]
            public object Params { get; private set; } = new object();
            [JsonPropertyName("resourceBundleLang")]
            public string ResourceBundleLang { get; private set; }

            public SendVerifySMSGIBStep2RequestModel()
            {
            }

            public SendVerifySMSGIBStep2RequestModel(string token, string userId)
            {
                Token = token;
                UserId = userId;
            }
        }

        public class SendVerifySMSGIBStep3RequestModel
        {
            [JsonIgnore]
            public string Token { get;private set; }
            [JsonPropertyName("CEPTEL")]
            public string PhoneNumber { get;private set; }
            [JsonPropertyName("KCEPTEL")]
            public bool PhoneNumber2 { get;private set; }
            [JsonPropertyName("TIP")]
            public string TIP { get; private set; }

            public SendVerifySMSGIBStep3RequestModel()
            {
            }

            public SendVerifySMSGIBStep3RequestModel(string token, string phoneNumber)
            {
                Token = token;
                PhoneNumber = phoneNumber;
                PhoneNumber2 = false;
                TIP = string.Empty;
            }
        }
    }
}

