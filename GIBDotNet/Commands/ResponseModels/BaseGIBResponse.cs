using System.Collections.Generic;

namespace GIBDotNet.Commands.ResponseModels
{
    public class BaseGIBResponse<TResponse>
        where TResponse : class, new()
    {
        /// <summary>
        /// GIB tarafından dönen cevabı tutar
        /// </summary>
        public TResponse Data { get; private set; }
        /// <summary>
        /// İşlemin başarılı olup olmadığını tutar
        /// </summary>
        public bool IsSuccess { get; private set; }
        /// <summary>
        /// GIB tarafından dönen hataları tutar
        /// </summary>
        public IEnumerable<string> Errors { get; set; }

        public BaseGIBResponse()
        {
            Errors = new List<string>();
        }

        public void Fail()
        {
            IsSuccess = false;
        }

        public void Fail(IEnumerable<string> errors)
        {
            IsSuccess = false;
            Errors = errors;
        }

        public void Success(TResponse data)
        {
            IsSuccess = true;
            Data = data;
        }
    }
}