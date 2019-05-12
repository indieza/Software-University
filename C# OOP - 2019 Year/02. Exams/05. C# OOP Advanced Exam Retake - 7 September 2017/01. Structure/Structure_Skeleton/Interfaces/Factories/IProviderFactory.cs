using System.Collections.Generic;

public interface IProviderFactory
{
    IProvider GenerateProvider(IList<string> args);
}