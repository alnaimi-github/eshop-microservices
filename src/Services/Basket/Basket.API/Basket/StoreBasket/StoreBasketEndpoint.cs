namespace Basket.API.Basket.StoreBasket;

public sealed record StoreBasketRequest(ShoppingCart Cart);
public sealed record StoreBasketResponse(string UserName);
public class StoreBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket",
            async (StoreBasketRequest request,ISender sender) =>
            {
                var command = request.Adapt<StoreBasketCommand>();
                var result = await sender.Send(command);

                var response = result.Adapt<StoreBasketResponse>();
                return Results.CreatedAtRoute(nameof(GetBasket),
                    new {userName = response.UserName}
                    ,response);
            })
            .WithName("PostBasket")
            .WithSummary("Post Basket")
            .WithDescription("Post Basket");
    }
}