using UserService.Application.Commands.Contract;
using UserService.Core.ValueObjects;
using MediatR;

namespace UserService.Application.Commands.InsertUserAddress
{
    public class InsertUserAddressInputModel : IRequest<ICommandResult<int>>
    {
        public int userId { get; set; }
        public int number { get; set; }
        public string address { get; set; }
        public ZipCode zip_code { get; set; }
        public OnlyLetters state { get; set; }
        public OnlyLetters city { get; set; }
        public string district { get; set; }
        public string information_additional { get; set; }
    }
}
