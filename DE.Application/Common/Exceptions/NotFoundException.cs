namespace DE.Application.Common.Exceptions;

public class NotFoundException : Domain.Exceptions.ApplicationException
{
    public NotFoundException(string name, object key)
        : base("Not Found", $"Entity \"{name}\" ({key}) not found.")
    {
    }

    public NotFoundException(string name)
        : base("Not Found", $"Entity \"{name}\" not found.")
    {
    }
}