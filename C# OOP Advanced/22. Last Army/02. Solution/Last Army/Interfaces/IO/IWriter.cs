public interface IWriter
{
    void WriteLine(string output);

    void StoreMessage(string performMission);

    string StoredMessage();
}