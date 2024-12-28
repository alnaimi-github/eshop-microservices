namespace Catalog.API.Modules;

public class Product
{
   

    public Guid Id { get;set; }
    public string Name { get; set; }
    public List<string> Category { get; set; }
    public string Description { get; set; }
    public string ImageFile { get;  set; }
    public decimal Price { get;  set; }

   
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
