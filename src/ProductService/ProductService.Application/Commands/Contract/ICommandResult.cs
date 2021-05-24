using System.Net;

namespace ProductService.Application.Commands.Contract
{
    public interface ICommandResult<T>
    {
        public HttpStatusCode httpStatusCode { get; init; }
        public bool success { get; init; }
        public string message { get; init; }
        public T response { get; init; }
    }
}
