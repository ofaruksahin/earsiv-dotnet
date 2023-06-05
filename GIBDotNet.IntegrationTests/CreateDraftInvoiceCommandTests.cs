using GIBDotNet.Commands.RequestModels;

namespace GIBDotNet.IntegrationTests
{
    [Collection(BaseTests.CollectionName)]
    public class CreateDraftInvoiceCommandTests : BaseTests
    {
        [Fact]
        public async Task WhenCorrectInvoiceReturnsSuccess()
        {
            var gibService = GIBService;
            var getTokenResponse = await gibService.GetToken(TestUserId, TestPassword);
            Assert.True(getTokenResponse.IsSuccess, getTokenResponse.Errors.FirstOrDefault());

            CreateDraftInvoiceRequestModel requestModel = new CreateDraftInvoiceRequestModel
            {
                Token = getTokenResponse.Data.Token,
                Ettn = Guid.NewGuid().ToString(),
                InvoiceDate = DateTime.Now,
                VKN = "11111111111",
                Name = "Ömer Faruk",
                Surname = "Şahin",
                TaxOffice = string.Empty,
                Address = "Test mahallesi, test sokak",
                SubTotal = 118,
                Tax = 18,
                Piece = 1
            };

            requestModel.AddItem(new CreateDraftInvoiceRequestModel.CreateDraftInvoiceItemRequestModel
            {
                Name = "Test ürünü",
                Piece = 1,
                SubTotal = 118,
                Tax = 18
            });

            var response = await gibService.CreateDraftInvoice(requestModel);
        }
    }
}
