namespace GIBDotNet.Commands.RequestModels
{
    public class GetTokenCommandRequestModel
    {
        /// <summary>
        /// GIB tarafından verilmiş portal kullanıcı adı
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// GIB tarafından verilmiş portal şifresi
        /// </summary>
        public string Password { get; set; }

        public static GetTokenCommandRequestModel Create(string userId, string password)
        {
            return new GetTokenCommandRequestModel
            {
                UserId = userId,
                Password = password
            };
        }
    }
}