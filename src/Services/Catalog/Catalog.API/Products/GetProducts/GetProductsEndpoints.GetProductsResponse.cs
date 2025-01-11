namespace Catalog.API.Products.GetProducts;

public sealed record GetProductsResponse(IEnumerable<Product> Products);