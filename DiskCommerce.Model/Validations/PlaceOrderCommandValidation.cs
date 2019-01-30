using DiskCommerce.Domain.Commands;
using FluentValidation;

public class PlaceOrderCommandValidation : AbstractValidator<PlaceOrderCommand>
{
    public PlaceOrderCommandValidation()
    {
        RuleFor(order => order.BuyerId).NotNull().WithMessage("BuyerId cannot be null");
        RuleFor(order => order.basketItems.Count).GreaterThanOrEqualTo(0).WithMessage("Basket is empty");
        RuleForEach(order => order.basketItems).NotNull().WithMessage("Basket item cannot be empty");
    }
}

