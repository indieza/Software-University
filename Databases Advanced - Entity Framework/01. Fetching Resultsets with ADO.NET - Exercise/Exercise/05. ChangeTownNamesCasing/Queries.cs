namespace _05._ChangeTownNamesCasing
{
    public static class Queries
    {
        public const string EditTownNames = @"UPDATE Towns
                                         SET Name = UPPER(Name)
                                       WHERE CountryCode = (
                                      SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

        public const string FindEditedTowns = @" SELECT t.Name
                                                   FROM Towns as t
                                                   JOIN Countries AS c ON c.Id = t.CountryCode
                                                  WHERE c.Name = @countryName";
    }
}