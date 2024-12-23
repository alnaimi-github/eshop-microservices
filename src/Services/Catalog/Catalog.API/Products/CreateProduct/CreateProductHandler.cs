using Catalog.API.Modules;

namespace Catalog.API.Products.CreateProduct;

internal class CreateProductHandler
: ICommandHandler<CreateProductCommand,
  CreateProductResult>
{
    public async Task<CreateProductResult> Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        var product = Product.Create(command.ProductDto);

        return new CreateProductResult(product.Id);
    }
}