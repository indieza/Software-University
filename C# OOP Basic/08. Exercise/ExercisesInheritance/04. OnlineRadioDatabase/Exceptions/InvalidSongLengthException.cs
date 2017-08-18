using System;

public class InvalidSongLengthException : InvalidSongException
{
    public override string Message => "Invalid song length.";

    public InvalidSongLengthException(string message) : base(message)
    {
    }

    public InvalidSongLengthException(string message, Exception innterException) : base(message, innterException)
    {
    }

    public InvalidSongLengthException()
    {
    }
}