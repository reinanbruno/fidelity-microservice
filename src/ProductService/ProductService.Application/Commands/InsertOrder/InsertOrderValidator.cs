using FluentValidation;

namespace ProductService.Application.Commands.InsertOrder
{
    public class InsertOrderValidator : AbstractValidator<InsertOrderInputModel>
    {
        public InsertOrderValidator()
        {
            RuleFor(c => c.userId)
                   .NotNull()
                   .NotEmpty()
                   .GreaterThan(0)
                   .WithName("Id do usuário");

            RuleFor(c => c.productId)
                   .NotNull()
                   .NotEmpty()
                   .GreaterThan(0)
                   .WithName("Id do produto");

            RuleFor(c => c.userAddressId)
                   .NotNull()
                   .NotEmpty()
                   .GreaterThan(0)
                   .WithName("Id do endereço do usuário");
        }
    }
}
