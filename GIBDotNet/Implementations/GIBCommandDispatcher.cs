using GIBDotNet.Contracts;
using System.Threading.Tasks;

namespace GIBDotNet.Implementations
{
    public class GIBCommandDispatcher : IGIBCommandDispatcher
    {
        public async Task<TResponse> Dispatch<TRequest, TResponse>(IGIBCommand<TRequest, TResponse> command, TRequest request)
            where TRequest : class, new()
            where TResponse : class, new()
        {
            using (command)
                return await command.DispatchCommand(request);
        }
    }
}
