using FluentValidation;

namespace UserService.Application.Commands.InsertUser
{
    public class InsertUserValidator : AbstractValidator<InsertUserInputModel>
    {
        public InsertUserValidator()
        {
            RuleFor(c => c.email.ToString())
                   .NotNull()
                   .MaximumLength(100)
                   .WithName("E-mail");

            RuleFor(c => c.cellphone.ToString())
                   .NotNull()
                   .MaximumLength(15)
                   .WithName("Telefone");

            RuleFor(c => c.name.ToString())
                   .NotNull()
                   .MinimumLength(3)
                   .MaximumLength(100)
                   .WithName("Nome");

            RuleFor(c => c.individualTaxpayerRegistration.ToString())
                   .NotNull()
                   .MaximumLength(11)
                   .WithName("CPF");

            RuleFor(c => c.birthDate)
                   .NotNull()
                   .NotEmpty()
                   .WithName("Data de nascimento");

            RuleFor(c => c.password)
                   .NotNull()
                   .NotEmpty()
                   .MinimumLength(6)
                   .MaximumLength(100)
                   .WithName("Senha");

            RuleFor(c => c.currentPointsValue)
                   .GreaterThanOrEqualTo(0)
                   .WithName("Saldo do usuário");
        }
    }
}
