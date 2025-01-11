﻿namespace Catalog.API.Products.DeleteProduct;

public sealed record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
public sealed record DeleteProductResult(bool IsSuccess);
public class DeleteProductHandler(IDocumentSession documentSession) 
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, 
        CancellationToken cancellationToken)
    {
        var product = await documentSession.LoadAsync<Product>(command.Id, cancellationToken);
        if (product is null)
        {
            throw new ProductNotFoundException(command.Id);
        }

        documentSession.Delete(product);
       await documentSession.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}