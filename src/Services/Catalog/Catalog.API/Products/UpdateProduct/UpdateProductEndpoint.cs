namespace Catalog.API.Products.UpdateProduct;

public sealed record UpdateProductRequest(ProductUpdateDto Product);
public sealed record UpdateProductResponse(bool IsSuccess);

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("products", 
            async (
                UpdateProductRequest request,
                ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();
                var result = await sender.Send(command);

                var response = result.Adapt<UpdateProductResponse>();
                return Results.Ok(response);
            })
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithName("UpdateProduct")
            .WithSummary("Update Product")
            .WithDescription("Update Product");
    }
}