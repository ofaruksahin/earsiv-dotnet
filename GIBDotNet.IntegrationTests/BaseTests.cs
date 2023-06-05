using GIBDotNet.Contracts;
using GIBDotNet.Implementations;
using GIBDotNet.Options;

namespace GIBDotNet.IntegrationTests
{
    public abstract class BaseTests
    {
        public const string CollectionName = "GIBDotNet";
        protected string TestUserId => "33333305";
        protected string TestPassword = "1";

        public IGIBService GIBService
        {
            get
            {
                GIBOptions.EnableTestMode();
                return new GIBService();
            }
        }
    }
}
