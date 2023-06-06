using GIBDotNet.Commands.RequestModels;
using GIBDotNet.Commands.ResponseModels;
using System;
using System.Threading.Tasks;

namespace GIBDotNet.Contracts
{
    public interface IGIBService
    {
        /// <summary>
        /// GIB tarafında oturum açmak için kullanılır
        /// </summary>
        /// <param name="userId">GIB tarafından size tahsis edilmiş kullanıcı adı</param>
        /// <param name="password">GIB tarafından size tahsis edilmiş şifre</param>
        /// <returns></returns>
        Task<BaseGIBResponse<GetTokenCommandResponseModel>> GetToken(string userId, string password);

        /// <summary>
        /// GIB tarafında açtığınız oturumu sonlandırmak için kullanılır
        /// </summary>
        /// <param name="token">GetToken metodu yardımıyla elde ettiğiniz token</param>
        /// <returns></returns>
        Task<BaseGIBResponse<LogoutCommandResponseModel>> Logout(string token);

        /// <summary>
        /// Taslak fatura oluşturmak için kullanılır
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        Task<BaseGIBResponse<CreateDraftInvoiceCommandResponseModel>> CreateDraftInvoice(CreateDraftInvoiceRequestModel invoice);

        /// <summary>
        /// İlgili faturayı xml ve html olarak zipli bir halde indirmek için kullanılır
        /// </summary>
        /// <param name="token">GetToken metodu vasıtasıyla elde ettiğiniz token</param>
        /// <param name="ettn">Taslak fatura oluştururken verdiğiniz ettn numarası</param>
        /// <returns></returns>
        Task<BaseGIBResponse<DownloadHTMLCommandResponseModel>> DownloadHTML(string token, string ettn);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="ettn"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<BaseGIBResponse<GetInvoiceByEttnResponseModel>> GetInvoiceByEttn(string token, string ettn, DateTime startDate, DateTime endDate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<BaseGIBResponse<GetInvoicesByDateRangeCommandResponseModel>> GetInvoiceByDateRange(string token, DateTime startDate, DateTime endDate);
    }
}