namespace Ordering.Domain.Exceptions;

public sealed class DomainException(string message)
    : Exception($"Domain Exception: \"{message}\" throws from domain layer.")
{
}