namespace GIBDotNet.IntegrationTests
{
    [Collection(BaseTests.CollectionName)]
    public class DeleteInvoiceCommandTests : BaseTests
    {
        [Fact]
        public async Task WhenCorrectInvoiceDeleteReturnsSucess()
        {
            var createDraftInvoiceTests = new CreateDraftInvoiceCommandTests();
            var ettn = await createDraftInvoiceTests.WhenCorrectInvoiceReturnsSuccess();

            Assert.NotEmpty(ettn);

            var gibService = GIBService;
            var getTokenResponse = await gibService.GetToken(TestUserId, TestPassword);
            Assert.True(getTokenResponse.IsSuccess);

            var startDate = DateTime.Now.AddDays(-1);
            var endDate = DateTime.Now;
            var invoice = await gibService.GetInvoiceByEttn(getTokenResponse.Data.Token, ettn, startDate, endDate);

            var response = await gibService.DeleteInvoice(getTokenResponse.Data.Token, invoice.Data, "f");

            Assert.True(response.IsSuccess);
        }
    }
}
