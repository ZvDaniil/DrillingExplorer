namespace DE.Domain.Exceptions;

public abstract class ApplicationException : Exception
{
    public string Title { get; }

    protected ApplicationException(string title, string message)
        : base(message) =>
        Title = title;
}