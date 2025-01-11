namespace Catalog.API.Products.GetProductByCategory;
public sealed record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;
public sealed record GetProductByCategoryResult(IEnumerable<Product> Products);


public class GetProductByCategoryQueryHandler(IDocumentSession documentSession)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, 
        CancellationToken cancellationToken)
    {
        var products = await documentSession.Query<Product>()
            .Where(c => c.Category.Contains(query.Category))
            .ToListAsync(cancellationToken);
                       

        if (products is null)
        {
            throw new ProductNotFoundException(query.Category);
        }

        return new GetProductByCategoryResult(products);
    }
}