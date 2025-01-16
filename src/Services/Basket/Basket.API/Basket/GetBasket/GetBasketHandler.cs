namespace Basket.API.Basket.GetBasket;

public sealed record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

public sealed record GetBasketResult(ShoppingCart Cart);
internal class GetBasketHandler (IBasketRepository repository)
    : IQueryHandler<GetBasketQuery,GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query,
        CancellationToken cancellationToken)
    {
        var basket = await repository.GetBasket(query.UserName, cancellationToken);

        return new GetBasketResult(basket);
    }
}