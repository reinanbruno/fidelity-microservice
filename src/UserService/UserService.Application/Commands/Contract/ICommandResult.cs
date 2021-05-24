using System.Net;

namespace UserService.Application.Commands.Contract
{
    public interface ICommandResult<T>
    {
        public HttpStatusCode httpStatusCode { get; init; }
        public bool success { get; init; }
        public string message { get; init; }
        public T response { get; init; }
    }
}
