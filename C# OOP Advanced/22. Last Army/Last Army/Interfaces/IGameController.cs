using System.Collections.Generic;

public interface IGameController
{
    void ProcessCommand(string input);

    void ProcessSoldierCommand(List<string> items);

    void ProduceSummury();
}