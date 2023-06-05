using System.Collections.Generic;

namespace GIBDotNet.Commands.ResponseModels
{
    public class BaseGIBResponse<TResponse>
        where TResponse : class, new()
    {
        public TResponse Data { get; private set; }
        public bool IsSuccess { get; private set; }
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
