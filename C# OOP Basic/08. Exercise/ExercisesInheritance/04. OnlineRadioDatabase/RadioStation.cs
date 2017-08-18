using System;
using System.Collections.Generic;
using System.Linq;

public class RadioStation
{
    private List<Song> playlist;

    public void AddSong(Song song)
    {
        this.playlist.Add(song);

        Console.WriteLine("Song added.");
    }

    private int[] CalculatePlaylistLength()
    {
        var total = this.playlist.Sum(x => x.Minutes * 60 + x.Seconds);
        var time = TimeSpan.FromSeconds(total);

        return new[] { time.Hours, time.Minutes, time.Seconds };
    }

    public override string ToString()
    {
        var length = this.CalculatePlaylistLength();

        return $"Songs added: {this.playlist.Count}\n" +
               $"Playlist length: {length[0]}h {length[1]}m {length[2]}s";
    }

    public RadioStation()
    {
        this.playlist = new List<Song>();
    }
}