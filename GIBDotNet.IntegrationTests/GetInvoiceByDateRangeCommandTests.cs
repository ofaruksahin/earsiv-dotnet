namespace GIBDotNet.IntegrationTests
{
    [Collection(BaseTests.CollectionName)]
    public class GetInvoiceByDateRangeCommandTests : BaseTests
    {
        [Fact]
        public async Task WhenInvoiceByDateRangeSuccess()
        {
            var gibService = GIBService;
            var getTokenResponse = await gibService.GetToken(TestUserId, TestPassword);
            Assert.True(getTokenResponse.IsSuccess);

            var startDate = DateTime.Now.AddDays(-1);
            var endDate = DateTime.Now;

            var response = await gibService.GetInvoiceByDateRange(getTokenResponse.Data.Token, startDate, endDate);
            Assert.True(response.IsSuccess);
        }
    }
}

