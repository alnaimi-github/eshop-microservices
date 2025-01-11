namespace Catalog.API.Products.UpdateProduct;

internal class UpdateProductCommandHandler(IDocumentSession documentSession) 
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command,
        CancellationToken cancellationToken)
    {
        var product = await documentSession.LoadAsync<Product>(command.Product.Id,
            cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(command.Product);
        }

        product.Name = command.Product.Name;
        product.Category = command.Product.Category;
        product.Description = command.Product.Description;
        product.ImageFile = command.Product.ImageFile;
        product.Price = command.Product.Price;

        documentSession.Update(product);
        await documentSession.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}