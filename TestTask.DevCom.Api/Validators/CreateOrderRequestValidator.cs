using FluentValidation;
using TestTask.DevCom.Contracts.Order;

namespace TestTask.DevCom.Api.Validators;

public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(x => x.OrderCost).Must(x => x > 0.99M);
        RuleFor(x => x.ItemsDescription).NotEmpty().Length(10, 1000);
        RuleFor(x => x.ShippingAddress).NotEmpty().Length(10, 1000);
    }
}