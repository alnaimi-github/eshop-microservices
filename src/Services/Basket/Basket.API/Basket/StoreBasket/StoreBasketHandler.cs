﻿using Discount.Grpc;

namespace Basket.API.Basket.StoreBasket;

public sealed record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public sealed record StoreBasketResult(string UserName);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
    }
}
internal class StoreBasketHandler(IBasketRepository repository,
    DiscountProtoService.DiscountProtoServiceClient discountProto) 
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command,
        CancellationToken cancellationToken)
    {
        await DeductDiscount(command, cancellationToken);
        var basket = await repository.StoreBasket(command.Cart, cancellationToken);
        return new StoreBasketResult(basket.UserName);
    }

    private async Task DeductDiscount(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        foreach (var item in command.Cart.Items)
        {
            var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest {ProductName = item.ProductName},
                cancellationToken: cancellationToken);

            item.Price -= coupon.Amount;
        }
    }
}