using OpenTelemetry.Trace;

namespace Catalog.API.Products.GetProductById;

public sealed record GetProductByIdResponse(ProductDto Product);
public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("products/{id:guid}",
                async (Guid id,ISender sender) =>
        {
            var query = new GetProductByIdQuery(id);
            var result = await sender.Send(query);

            var response = result.Adapt<GetProductByIdResponse>();
            return Results.Ok(response);
        })
         .ProducesProblem(StatusCodes.Status404NotFound)
         .WithName("GetProductById")
         .WithSummary("Get Product By Id")
         .WithDescription("Get Product By Id");
    }
}