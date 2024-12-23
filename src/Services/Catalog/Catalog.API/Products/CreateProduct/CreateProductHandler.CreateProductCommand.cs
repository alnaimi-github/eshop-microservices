namespace Catalog.API.Products.CreateProduct;

public sealed record CreateProductCommand(ProductDto ProductDto) 
    : ICommand<CreateProductResult>;