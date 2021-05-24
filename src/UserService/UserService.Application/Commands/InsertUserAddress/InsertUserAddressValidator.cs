using FluentValidation;

namespace UserService.Application.Commands.InsertUserAddress
{
    public class InsertUserAddressValidator : AbstractValidator<InsertUserAddressInputModel>
    {
        public InsertUserAddressValidator()
        {
            RuleFor(c => c.userId)
                   .NotNull()
                   .NotEmpty()
                   .GreaterThan(0)
                   .WithName("Id do usuário");

            RuleFor(c => c.number)
                   .NotNull()
                   .NotEmpty()
                   .GreaterThan(0)
                   .WithName("Número do endereço");

            RuleFor(c => c.address)
                   .NotNull()
                   .NotEmpty()
                   .MaximumLength(100)
                   .WithName("Descrição do endereço");

            RuleFor(c => c.zip_code.ToString())
                   .NotNull()
                   .MaximumLength(8)
                   .WithName("CEP");

            RuleFor(c => c.state.ToString())
                   .NotNull()
                   .Length(2)
                   .WithName("Estado");

            RuleFor(c => c.city.ToString())
                   .NotNull()
                   .MaximumLength(100)
                   .WithName("Cidade");

            RuleFor(c => c.district)
                   .NotNull()
                   .NotEmpty()
                   .MaximumLength(100)
                   .WithName("Bairro");

        }
    }
}
