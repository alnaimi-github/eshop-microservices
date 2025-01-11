namespace Catalog.API.Dtos;

public sealed record ProductUpdateDto(
    Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);