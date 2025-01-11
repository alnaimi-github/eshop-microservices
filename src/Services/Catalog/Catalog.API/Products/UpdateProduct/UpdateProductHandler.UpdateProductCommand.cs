namespace Catalog.API.Products.UpdateProduct;

public sealed record UpdateProductCommand(ProductUpdateDto Product) : ICommand<UpdateProductResult>;