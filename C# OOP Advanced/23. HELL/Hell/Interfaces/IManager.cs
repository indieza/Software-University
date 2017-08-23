using System.Collections.Generic;

public interface IManager
{
    string Quit(object argsList);

    string AddRecipe(IList<string> args);

    string AddItem(IList<string> args);

    string Inspect(IList<string> args);

    string AddHero(IList<string> args);
}