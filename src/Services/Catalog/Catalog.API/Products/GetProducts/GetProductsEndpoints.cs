namespace Catalog.API.Products.GetProducts;

public class GetProductsEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products",
                async ([AsParameters] GetProductsRequest request, ISender sender) =>
                {
                    var query = request.Adapt<GetProductsQuery>();
                    var result = await sender.Send(query);

                    var response = result.Adapt<GetProductsResponse>();
                    return Results.Ok(response);
                })
            .WithName("GetProducts")
            .WithSummary("Get Products")
            .WithDescription("Get Products");
    }
}