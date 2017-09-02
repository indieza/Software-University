using System.Collections.Generic;

public class Army : IArmy
{
    public IReadOnlyList<ISoldier> Soldiers { get; }

    public void AddSoldier(ISoldier soldier)
    {
        throw new System.NotImplementedException();
    }

    public void RegenerateTeam(string soldierType)
    {
        throw new System.NotImplementedException();
    }
}