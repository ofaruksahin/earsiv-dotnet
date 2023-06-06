namespace GIBDotNet.IntegrationTests
{
    [Collection(BaseTests.CollectionName)]
    public class GetInvoiceByEttnCommandTests : BaseTests
    {
        [Fact]
        public async Task WhenCorrectInvoiceReturnsSuccess()
        {
            var createDraftInvoiceTests = new CreateDraftInvoiceCommandTests();
            var ettn = await createDraftInvoiceTests.WhenCorrectInvoiceReturnsSuccess();

            Assert.NotEmpty(ettn);

            var gibService = GIBService;
            var getTokenResponse = await gibService.GetToken(TestUserId, TestPassword);
            Assert.True(getTokenResponse.IsSuccess);

            var startDate = DateTime.Now.AddDays(-1);
            var endDate = DateTime.Now;
            var response = await gibService.GetInvoiceByEttn(getTokenResponse.Data.Token,ettn,startDate,endDate);

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task WhenIncorrectEttnReturnsFail()
        {
            var gibService = GIBService;
            var getTokenResponse = await gibService.GetToken(TestUserId, TestPassword);
            Assert.True(getTokenResponse.IsSuccess);

            var startDate = DateTime.Now.AddDays(-1);
            var endDate = DateTime.Now;
            var response = await gibService.GetInvoiceByEttn(getTokenResponse.Data.Token, Guid.NewGuid().ToString(), startDate, endDate); ;

            Assert.False(response.IsSuccess);
        }
    }
}
