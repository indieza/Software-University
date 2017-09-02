public interface IWriter
{
    void WriteLine(string output);

    void StoreMessage(string argMessage);

    string StoredMessage { get; }
}