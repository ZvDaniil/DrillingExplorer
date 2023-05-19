namespace DE.Application.Common.Exceptions;

public sealed class ValidationException : Domain.Exceptions.ApplicationException
{
    public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }

    public ValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary)
        : base("Validation Failure", "One or more validation errors occurred") =>
        ErrorsDictionary = errorsDictionary;
}