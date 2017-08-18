using System;

internal class InvalidArtistNameException : InvalidSongException
{
    public override string Message => "Artist name should be between 3 and 20 symbols.";

    public InvalidArtistNameException(string message) : base(message)
    {
    }

    public InvalidArtistNameException(string message, Exception innterException) : base(message, innterException)
    {
    }

    public InvalidArtistNameException()
    {
    }
}