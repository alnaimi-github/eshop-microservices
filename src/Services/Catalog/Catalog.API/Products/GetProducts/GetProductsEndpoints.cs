using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProducts;

public sealed record GetProductsResponse(IEnumerable<Product> Products);
public class GetProductsEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products",
                async (ISender sender) =>
                {
                    var query = new GetProductsQuery();
                    var result = await sender.Send(query);

                    var response = result.Adapt<GetProductsResponse>();
                    return Results.Ok(response);
                })
            .WithName("GetProducts")
            .WithSummary("Get Products")
            .WithDescription("Get Products");
    }
}