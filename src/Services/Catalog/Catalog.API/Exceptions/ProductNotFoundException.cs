﻿using BuildingBlocks.Exceptions;

namespace Catalog.API.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid Id) : base("Product", Id)
    {
    }
    public ProductNotFoundException(object message) : base($"Product By {message} not found!")
    {

    }
}