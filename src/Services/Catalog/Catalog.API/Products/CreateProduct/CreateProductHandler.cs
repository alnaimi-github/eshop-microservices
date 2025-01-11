namespace Catalog.API.Products.CreateProduct;

internal class CreateProductHandler(IDocumentSession documentSession)
    : ICommandHandler<CreateProductCommand,
    CreateProductResult>
{
    public async Task<CreateProductResult> Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        var product = Product.Create(command.ProductDto);

        documentSession.Store(product);
        await documentSession.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }
}