namespace Catalog.API.Products.GetProducts;

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