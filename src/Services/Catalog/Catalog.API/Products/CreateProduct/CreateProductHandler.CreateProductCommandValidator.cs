namespace Catalog.API.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.ProductDto.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.ProductDto.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.ProductDto.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.ProductDto.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}