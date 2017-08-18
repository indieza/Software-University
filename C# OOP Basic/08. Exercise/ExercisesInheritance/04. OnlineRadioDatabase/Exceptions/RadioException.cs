using System;

public abstract class RadioException : Exception
{
    protected RadioException(string message) : base(message)
    {
    }

    protected RadioException(string message, Exception innterException) : base(message, innterException)
    {
    }

    protected RadioException()
    {
    }
}