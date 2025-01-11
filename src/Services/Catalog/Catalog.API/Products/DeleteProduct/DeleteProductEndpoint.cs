namespace Catalog.API.Products.DeleteProduct;

public sealed record DeleteProductResponse(bool IsSuccess);
public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("products/{id:guid}",
            async (Guid id,ISender sender) =>
            {
                var command = new DeleteProductCommand(id);
                var result = await sender.Send(command);

                var response = result.Adapt<DeleteProductResponse>();
                return Results.Ok(response);
            })
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithName("DeleteProduct")
            .WithSummary("Delete Product")
            .WithDescription("Delete Product");
    }
}