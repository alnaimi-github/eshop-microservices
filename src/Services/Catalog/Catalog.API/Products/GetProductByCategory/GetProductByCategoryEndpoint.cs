namespace Catalog.API.Products.GetProductByCategory;

public sealed record GetProductByCategoryResponse(IEnumerable<ProductDto> Products);
public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("products/category/{category}",
            async (string category, ISender sender) =>
            {
                var query = new GetProductByCategoryQuery(category);
                var result = await sender.Send(query);

                var response = result.Adapt<GetProductByCategoryResponse>();
                return Results.Ok(response);
            })
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithName("GetProductByCategory")
            .WithSummary("Get Product By Category")
            .WithDescription("Get Product By Category");
    }
}