using UserService.Application.Commands.Contract;
using UserService.Core.ValueObjects;
using MediatR;
using System;

namespace UserService.Application.Commands.InsertUser
{
    public class InsertUserInputModel : IRequest<ICommandResult<int>>
    {
        public OnlyLetters name { get; set; }
        public Email email { get; set; }
        public IndividualTaxpayerRegistration individualTaxpayerRegistration { get; set; }
        public Cellphone cellphone { get; set; }
        public DateTime birthDate { get; set; }
        public String password { get; set; }
        public decimal currentPointsValue { get; set; }
    }
}
