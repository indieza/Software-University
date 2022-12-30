namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using AutoMapper;

    using Data;

    using Footballers.DataProcessor.ExportDto;

    using Microsoft.EntityFrameworkCore;

    using Newtonsoft.Json;

    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            throw new NotImplementedException();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var data = context.Teams
                .Where(x => x.TeamsFootballers.Any(x => x.Footballer.ContractStartDate >= date))
                .Select(x => new
                {
                    x.Name,
                    Footballers = x.TeamsFootballers
                        .Where(x => x.Footballer.ContractStartDate >= date)
                        .ToList(),
                })
                .ToList()
                .OrderByDescending(x => x.Footballers.Count())
                .ThenBy(x => x.Name)
                .Take(5)
                .Select(x => new TeamExportDto()
                {
                    Name = x.Name,
                    Footballers = x.Footballers
                        .OrderByDescending(x => x.Footballer.ContractEndDate)
                        .ThenBy(x => x.Footballer.Name)
                        .Select(y => new FootballerExportDto()
                        {
                            BestSkillType = y.Footballer.BestSkillType
                                .ToString(),
                            ContractEndDate = y.Footballer.ContractEndDate
                                .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                            ContractStartDate = y.Footballer.ContractStartDate
                                .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                            FootballerName = y.Footballer.Name,
                            PositionType = y.Footballer.PositionType
                                .ToString(),
                        })
                        .ToList()
                })
                .ToList();

            var export = JsonConvert.SerializeObject(data, Formatting.Indented);
            return export.Trim();
        }
    }
}