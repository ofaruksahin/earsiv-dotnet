using GIBDotNet.Commands.ResponseModels;
using System;
using System.Threading.Tasks;

namespace GIBDotNet.Contracts
{
    public interface IGIBCommand<TRequest, TResponse> : IDisposable
        where TRequest : class, new()
        where TResponse : class, new()
    {
        Task<BaseGIBResponse<TResponse>> DispatchCommand(TRequest requestModel);
    }
}