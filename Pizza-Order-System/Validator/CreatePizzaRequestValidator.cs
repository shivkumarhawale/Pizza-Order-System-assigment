using FluentValidation;
using Pizza_Order_System.Application.Contract.Request;

namespace Pizza_Order_System.Validator
{
    public class CreatePizzaRequestValidator : AbstractValidator<CreatePizzaRequest>
    {
        public CreatePizzaRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name required");
            RuleFor(p => p.Size).NotEqual(0).WithMessage("Size required");
            RuleFor(p => p.NumberOfPizza).NotEqual(0).WithMessage("Number of pizza required");
        }
    }
}
