namespace Catalog.API.Products.GetProducts;

public sealed record GetProductsResult(IEnumerable<Product> Products);