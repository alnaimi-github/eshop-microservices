namespace Catalog.API.Dtos;

public sealed record ProductDto(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);