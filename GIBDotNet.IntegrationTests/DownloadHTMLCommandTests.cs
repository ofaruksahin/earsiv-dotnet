namespace GIBDotNet.IntegrationTests
{
    [Collection(BaseTests.CollectionName)]
    public class DownloadHTMLCommandTests : BaseTests
    {
        [Fact]
        public async Task WhenCreatedDraftInvoiceDownloadHTMLReturnsByteArray()
        {
            CreateDraftInvoiceCommandTests createDraftInvoiceCommandTests = new CreateDraftInvoiceCommandTests();

            var ettn = await createDraftInvoiceCommandTests.WhenCorrectInvoiceReturnsSuccess();

            var gibService = GIBService;

            var getTokenResponse = await gibService.GetToken(TestUserId, TestPassword);

            Assert.True(getTokenResponse.IsSuccess);

            var byteArr =  await gibService.DownloadHTML(getTokenResponse.Data.Token, ettn);

            Assert.NotEmpty(byteArr.Data.Data);
        }
    }
}
