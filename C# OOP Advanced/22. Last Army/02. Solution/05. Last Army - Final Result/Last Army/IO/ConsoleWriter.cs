using System;
using System.Text;

internal class ConsoleWriter : IWriter
{
    private StringBuilder sd;

    public ConsoleWriter()
    {
        this.sd = new StringBuilder();
    }

    public string StoredMessage()
    {
        return this.sd.ToString().Trim();
    }

    public void WriteLine(string output)
    {
        Console.WriteLine(output.Trim());
    }

    public void StoreMessage(string text)
    {
        this.sd.AppendLine(text.Trim());
    }
}