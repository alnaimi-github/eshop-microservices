namespace Catalog.API.Modules;

public class Product
{
   

    public Guid Id { get;private set; }
    public string Name { get; private set; }
    public List<string> Category { get; private set; }
    public string Description { get; private set; }
    public string ImageFile { get; private set; }
    public decimal Price { get; private set; }

   
        public static Product  Create(ProductDto productDto)
        {
            var product = new Product
            { 
                Id = Guid.NewGuid(),
                Name = productDto.Name,
                Category = productDto.Category,
                Description = productDto.Description,
                ImageFile = productDto.ImageFile,
                Price = productDto.Price

            };
  
            return product;
        }
}
