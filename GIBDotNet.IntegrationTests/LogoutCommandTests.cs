namespace GIBDotNet.IntegrationTests
{
    [Collection(BaseTests.CollectionName)]
    public class LogoutCommandTests : BaseTests
    {
        [Fact]
        public async Task WhenValidTokenLogoutReturnsSuccess()
        {
            var gibService = GIBService;
            var getTokenResponse = await gibService.GetToken(TestUserId, TestPassword);

            Assert.True(getTokenResponse.IsSuccess, getTokenResponse.Errors.FirstOrDefault());

            var logoutResponse = await gibService.Logout(getTokenResponse.Data.Token);

            Assert.True(logoutResponse.IsSuccess, logoutResponse.Errors.FirstOrDefault());
        }

        [Fact]
        public async Task WhenInvalidTokenLogoutReturnsFail()
        {
            var gibService = GIBService;

            var logoutResponse = await gibService.Logout(string.Empty);

            Assert.False(logoutResponse.IsSuccess, logoutResponse.Errors.FirstOrDefault());
        }
    }
}