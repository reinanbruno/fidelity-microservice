using FluentValidation;

namespace UserService.Application.Commands.Authenticate
{
    public class AuthenticateUserValidator : AbstractValidator<AuthenticateUserInputModel>
    {
        public AuthenticateUserValidator()
        {
            RuleFor(c => c.email.ToString())
                   .NotNull()
                   .MaximumLength(100)
                   .WithName("E-mail");

            RuleFor(c => c.password)
                   .NotNull()
                   .NotEmpty()
                   .MinimumLength(6)
                   .MaximumLength(100)
                   .WithName("Senha");
        }
    }
}
