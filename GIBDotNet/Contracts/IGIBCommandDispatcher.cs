using GIBDotNet.Commands.ResponseModels;
using System.Threading.Tasks;

namespace GIBDotNet.Contracts
{
    public interface IGIBCommandDispatcher
    {
        Task<BaseGIBResponse<TResponse>> Dispatch<TRequest, TResponse>(IGIBCommand<TRequest, TResponse> command, TRequest request)
            where TRequest : class, new()
            where TResponse : class, new();
    }
}
