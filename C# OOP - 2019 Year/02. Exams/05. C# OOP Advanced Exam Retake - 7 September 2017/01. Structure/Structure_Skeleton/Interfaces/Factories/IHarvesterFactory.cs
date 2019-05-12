using System.Collections.Generic;

public interface IHarvesterFactory
{
    IHarvester GenerateHarvester(IList<string> args);
}