namespace GIBDotNet.IntegrationTests
{
    [Collection(BaseTests.CollectionName)]
    public class GetTokenCommandTests : BaseTests
    {
        [Fact]        
        public async Task WhenCorrectCredentialsReturnsSuccess()
        {
            var gibService = GIBService;
            var getTokenResponse = await gibService.GetToken(TestUserId, TestPassword);
            Assert.True(getTokenResponse.IsSuccess,getTokenResponse.Errors.FirstOrDefault());
            await gibService.Logout(getTokenResponse.Data.Token);
        }

        [Fact]
        public async Task WhenIncorrectCredentialsReturnsFail()
        {
            var gibService = GIBService;
            var getTokenResponse = await gibService.GetToken(TestUserId, "");
            Assert.False(getTokenResponse.IsSuccess,getTokenResponse.Errors.FirstOrDefault());
        }
    }
}
