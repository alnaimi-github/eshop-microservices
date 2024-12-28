using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProducts;

public sealed record GetProductsQuery() : IQuery<GetProductsResult>;

public sealed record GetProductsResult(IEnumerable<Product> Products);
public class GetProductsHandler (
    IDocumentSession documentSession,
    ILogger<GetProductsQuery> logger)
    : IQueryHandler<GetProductsQuery,GetProductsResult>
{
    public async Task<GetProductsResult> Handle(
        GetProductsQuery query,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsQueryHandler.Handle called with {@Query}", query);

        var products = await documentSession.Query<Product>()
                                           .ToListAsync(cancellationToken);

        return new GetProductsResult(products);
    }
}