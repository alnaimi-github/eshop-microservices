﻿namespace Basket.API.Basket.GetBasket;

//public sealed record GetBasketRequest(string UserName);
public sealed record GetBasketResponse(ShoppingCart Cart);
public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", 
            async (string userName,ISender sender) =>
            {
                var result = await sender.Send(new GetBasketQuery(userName));

                var response = result.Adapt<GetBasketResponse>();
                return Results.Ok(response);
            })
            .WithName("GetBasket")
            .WithSummary("Get Basket")
            .WithDescription("Get Basket");
    }
}