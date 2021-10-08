using FluentValidation;
using Pizza_Order_System.Application.Contract.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Order_System.Application.Contract.Validator
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
