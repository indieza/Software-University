using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    private StringBuilder sb = new StringBuilder();

    public void WriteLine(string output)
    {
        Console.WriteLine(output);
    }

    public void StoreMessage(string argMessage)
    {
        throw new NotImplementedException();
    }

    public string StoredMessage => sb.ToString().Trim();
}