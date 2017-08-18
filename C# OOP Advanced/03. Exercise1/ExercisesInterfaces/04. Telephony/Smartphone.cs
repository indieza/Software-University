using System;
using System.Collections.Generic;
using System.Linq;

public class Smartphone : ICallable, IBrowsable
{
    private readonly IList<string> phones;
    private readonly IList<string> websites;

    public Smartphone()
    {
        this.phones = new List<string>();
        this.websites = new List<string>();
    }

    public string Call()
    {
        return string.Join(Environment.NewLine, this.phones);
    }

    public string Browse()
    {
        return string.Join(Environment.NewLine, this.websites);
    }

    public void AddPhone(string phone)
    {
        this.phones.Add(phone.Any(char.IsDigit) ? $"Calling... {phone}" : "Invalid number!");
    }

    public void AddWebsite(string website)
    {
        this.websites.Add(website.Any(char.IsDigit) ? "Invalid URL!" : $"Browsing: {website}!");
    }
}