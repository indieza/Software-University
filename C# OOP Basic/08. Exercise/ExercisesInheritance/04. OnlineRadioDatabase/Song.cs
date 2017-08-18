using System;

public class Song
{
    private string artist;
    private string name;
    private int minutes;
    private int seconds;

    public string Artist
    {
        get { return artist; }
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }

            artist = value;
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidSongNameException();
            }

            name = value;
        }
    }

    public int Minutes
    {
        get { return minutes; }
        set
        {
            if (value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }

            minutes = value;
        }
    }

    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }

            seconds = value;
        }
    }

    private void SetLength(string length)
    {
        string[] lengthTokens = length.Split(':');

        int minutes;
        int seconds;

        try
        {
            minutes = int.Parse(lengthTokens[0]);
            seconds = int.Parse(lengthTokens[1]);
        }
        catch (Exception)
        {
            throw new InvalidSongLengthException();
        }

        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public Song(string artistName, string songName, string length)
    {
        this.Artist = artistName;
        this.Name = songName;
        this.SetLength(length);
    }
}