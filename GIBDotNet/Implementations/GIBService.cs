using GIBDotNet.Commands;
using GIBDotNet.Commands.RequestModels;
using GIBDotNet.Commands.ResponseModels;
using GIBDotNet.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GIBDotNet.Implementations
{
    public class GIBService : IGIBService
    {
        private readonly IGIBCommandDispatcher _commandDispatcher;

        public GIBService()
        {
            _commandDispatcher = new GIBCommandDispatcher();
        }

        /// <summary>
        /// GIB tarafında oturum açmak için kullanılır
        /// </summary>
        /// <param name="userId">GIB tarafından size tahsis edilmiş kullanıcı adı</param>
        /// <param name="password">GIB tarafından size tahsis edilmiş şifre</param>
        /// <returns></returns>
        public Task<BaseGIBResponse<GetTokenCommandResponseModel>> GetToken(string userId, string password)
        {
            var requestModel = GetTokenCommandRequestModel.Create(userId, password);
            return _commandDispatcher.Dispatch(new GetTokenCommand(), requestModel);
        }

        /// <summary>
        /// GIB tarafında açtığınız oturumu sonlandırmak için kullanılır
        /// </summary>
        /// <param name="token">GetToken metodu yardımıyla elde ettiğiniz token</param>
        /// <returns></returns>
        public Task<BaseGIBResponse<LogoutCommandResponseModel>> Logout(string token)
        {
            var requestModel = LogoutCommandRequestModel.Create(token);
            return _commandDispatcher.Dispatch(new LogoutCommand(), requestModel);
        }

        /// <summary>
        /// Taslak fatura oluşturmak için kullanılır
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public Task<BaseGIBResponse<CreateDraftInvoiceCommandResponseModel>> CreateDraftInvoice(CreateDraftInvoiceRequestModel invoice)
        {
            return _commandDispatcher.Dispatch(new CreateDraftInvoiceCommand(), invoice);
        }

        /// <summary>
        /// İlgili faturayı xml ve html olarak zipli bir halde indirmek için kullanılır
        /// </summary>
        /// <param name="token">GetToken metodu vasıtasıyla elde ettiğiniz token</param>
        /// <param name="ettn">Taslak fatura oluştururken verdiğiniz ettn numarası</param>
        /// <returns></returns>
        public Task<BaseGIBResponse<DownloadHTMLCommandResponseModel>> DownloadHTML(string token, string ettn)
        {
            var requestModel = new DownloadHTMLCommandRequestModel(token, ettn);
            return _commandDispatcher.Dispatch(new DownloadHTMLCommand(), requestModel);
        }

        public Task<BaseGIBResponse<GetInvoiceByEttnResponseModel>> GetInvoiceByEttn(string token, string ettn, DateTime startDate, DateTime endDate)
        {
            var requestModel = new GetInvoiceByEttnRequestModel(token, ettn, startDate, endDate);
            return _commandDispatcher.Dispatch(new GetInvoiceByEttnCommand(), requestModel);
        }

        public Task<BaseGIBResponse<GetInvoicesByDateRangeCommandResponseModel>> GetInvoiceByDateRange(string token, DateTime startDate, DateTime endDate)
        {
            var requestModel = new GetInvoicesByDateRangeCommandRequestModel(token, startDate, endDate);
            return _commandDispatcher.Dispatch(new GetInvoicesByDateRangeCommand(), requestModel);
        }

        public Task<BaseGIBResponse<DeleteInvoiceCommandResponseModel>> DeleteInvoice(string token, GetInvoiceItem invoice, string cause)
        {
            var requestModel = new DeleteInvoiceCommandRequestModel(token, new List<GetInvoiceItem> { invoice }, cause);
            return _commandDispatcher.Dispatch(new DeleteInvoiceCommand(), requestModel);
        }

        public Task<BaseGIBResponse<DeleteInvoiceCommandResponseModel>> DeleteInvoices(string token, List<GetInvoiceItem> invoices, string cause)
        {
            var requestModel = new DeleteInvoiceCommandRequestModel(token, invoices, cause);
            return _commandDispatcher.Dispatch(new DeleteInvoiceCommand(), requestModel);
        }
    }
}