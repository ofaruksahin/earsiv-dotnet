using GIBDotNet.Options;
using RestSharp;
using System;
using System.Collections.Generic;

namespace GIBDotNet.Commands
{
    internal abstract class BaseGIBCommand : IDisposable
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

        private void PostCommand<TRequest, TResponse>(string url)
            where TRequest : class, new()
            where TResponse: class, new()
        {
            if (_client == null)
                _client = new RestClient($"{BaseUrl}");
            
            _request = new RestRequest(url,Method.Post);
            SetDefaultHeaders(_request);
        }

        private void SetDefaultHeaders(RestRequest request)
        {
            IDictionary<string, string> headers = new Dictionary<string, string>
            {
                {HeaderNameConstants.Connection,HeaderValueConstants.Connection },
                {HeaderNameConstants.SecChUa,HeaderValueConstants.SecChUa },
                {HeaderNameConstants.Accept,HeaderValueConstants.Accept },
                {HeaderNameConstants.DNT, HeaderValueConstants.DNT},
                {HeaderNameConstants.SecChUaMobile, HeaderValueConstants.SecChUaMobile},
                {HeaderNameConstants.UserAgent, HeaderValueConstants.UserAgent},
                {HeaderNameConstants.ContentType, HeaderValueConstants.ContentType},
                {"Origin",$"{BaseUrl.TrimEnd('/')}" },
                {HeaderNameConstants.SecFetchSite,HeaderValueConstants.SecFetchSite },
                {HeaderNameConstants.SecFetchMode,HeaderValueConstants.SecFetchMode},
                {HeaderNameConstants.SecFetchDest,HeaderValueConstants.SecFetchDest },
                //Referrer
                {HeaderNameConstants.AcceptLanguage,HeaderValueConstants.AcceptLanguage }
            };

            foreach(var header in headers)
                request.AddOrUpdateHeader(header.Key, header.Value);
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

            if(disposing)
            {
                if(_client != null)
                {
                    _client.Dispose();
                    _client = null;
                }

                if(_request != null)
                {
                    _request = null;
                }
            }

            _disposed = true;
        }
    }
}
