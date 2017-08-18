using System;

public class InvalidSongException : RadioException
{
    public override string Message => "Invalid song.";

    public InvalidSongException(string message) : base(message)
    {
    }

    public InvalidSongException(string message, Exception innterException) : base(message, innterException)
    {
    }

    public InvalidSongException()
    {
    }
}