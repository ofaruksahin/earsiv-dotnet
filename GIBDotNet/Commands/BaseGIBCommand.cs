using GIBDotNet.Commands.GIBResponseModels;
using GIBDotNet.Commands.ResponseModels;
using GIBDotNet.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GIBDotNet.Commands
{
    public abstract class BaseGIBCommand : IDisposable
    {
        private RestClient _client;
        private RestRequest _request;
        private bool _disposed;

        private string BaseUrl
        {
            get
            {
                if (GIBOptions.IsProduction)
                    return "https://earsivportal.efatura.gov.tr";
                return "https://earsivportaltest.efatura.gov.tr";
            }
        }

        protected void MakeCommand(string url)
        {
            if (_client == null)
                _client = new RestClient($"{BaseUrl}");

            _request = new RestRequest(url, Method.Post);
            SetDefaultHeaders(_request);
        }

        protected void AddParameter(string key, string value)
        {
            if (_request == null)
                throw new ArgumentNullException(nameof(RestRequest));

            _request.AddParameter(key, value);
        }

        protected void AddParameter(string value)
        {
            if (_request == null)
                throw new ArgumentNullException(nameof(RestRequest));

            _request.AddStringBody(value, "application/x-www-form-urlencoded");
        }

        protected void AddReferer(string referer)
        {
            if (_request == null)
                throw new ArgumentNullException(nameof(RestRequest));

            if (string.IsNullOrEmpty(referer)) return;

            if (GIBOptions.IsProduction)
                _request.AddHeader(HeaderNameConstants.Referer, $"https://earsivportal.efatura.gov.tr/{referer}");
            else
                _request.AddHeader(HeaderNameConstants.Referer, $"https://earsivportaltest.efatura.gov.tr/{referer}");
        }

        protected async Task<RestResponse> ExecuteCommand()
        {
            return await _client.ExecuteAsync(_request);
        }
        protected async Task<byte[]> DownloadData()
        {
            return await _client.DownloadDataAsync(_request);
        }

        private void SetDefaultHeaders(RestRequest request)
        {
            IDictionary<string, string> headers = new Dictionary<string, string>
            {
                {HeaderNameConstants.Connection,HeaderValueConstants.Connection},
                {HeaderNameConstants.SecChUa,HeaderValueConstants.SecChUa},
                {HeaderNameConstants.SecChUaMobile,HeaderValueConstants.SecChUaMobile},
                {HeaderNameConstants.UpgradeInsecureRequests,HeaderValueConstants.UpgradeInsecureRequests},
                {HeaderNameConstants.DNT, HeaderValueConstants.DNT},
                {HeaderNameConstants.UserAgent, HeaderValueConstants.UserAgent},
                {HeaderNameConstants.Accept, HeaderValueConstants.Accept},
                {HeaderNameConstants.SecFetchSite, HeaderValueConstants.SecFetchSite},
                {HeaderNameConstants.SecFetchMode, HeaderValueConstants.SecFetchMode},
                {HeaderNameConstants.SecFetchUser, HeaderValueConstants.SecFetchUser},
                {HeaderNameConstants.SecFetchDest, HeaderValueConstants.SecFetchDest},
                {HeaderNameConstants.AcceptLanguage, HeaderValueConstants.AcceptLanguage},
            };

            foreach (var header in headers)
                request.AddOrUpdateHeader(header.Key, header.Value);
        }

        protected bool ValidateResponse<TGIBResponse, TResponse>(RestResponse restResponse, out TGIBResponse gibResponse, out BaseGIBResponse<TResponse> responseModel)
            where TGIBResponse : BaseGIBResponseModel, new()
            where TResponse : class, new()
        {
            gibResponse = new TGIBResponse();
            responseModel = new BaseGIBResponse<TResponse>();

            if (!restResponse.IsSuccessStatusCode)
            {
                responseModel.Fail();
                return false;
            }

            var gibResponseSerialized = restResponse.Content;
            gibResponse = JsonSerializer.Deserialize<TGIBResponse>(gibResponseSerialized);

            if (!string.IsNullOrEmpty(gibResponse.Error))
            {
                responseModel.Fail(gibResponse.Messages.Select(f => f.Text));
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                if (_client != null)
                {
                    _client.Dispose();
                    _client = null;
                }

                if (_request != null)
                {
                    _request = null;
                }
            }

            _disposed = true;
        }
    }
}