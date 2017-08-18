using System;

public class InvalidSongSecondsException : InvalidSongLengthException
{
    public override string Message => "Song seconds should be between 0 and 59.";

    public InvalidSongSecondsException(string message) : base(message)
    {
    }

    public InvalidSongSecondsException(string message, Exception innterException) : base(message, innterException)
    {
    }

    public InvalidSongSecondsException()
    {
    }
}