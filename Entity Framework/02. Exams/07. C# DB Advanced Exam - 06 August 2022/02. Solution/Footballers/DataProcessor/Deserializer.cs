namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Xml.Serialization;

    using AutoMapper;

    using Data;

    using Footballers.Data.Models;
    using Footballers.DataProcessor.ImportDto;

    using Microsoft.EntityFrameworkCore.Internal;

    using Newtonsoft.Json;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(CoachImportDto[]), new XmlRootAttribute("Coaches"));
            using (StringReader reader = new StringReader(xmlString))
            {
                var coachesData = (CoachImportDto[])serializer.Deserialize(reader);
                var coaches = new List<Coach>();

                foreach (var coachData in coachesData)
                {
                    if (IsValid(coachData))
                    {
                        var coach = Mapper.Map<Coach>(coachData);

                        foreach (var footballerData in coachData.Footballers)
                        {
                            if (IsValid(footballerData))
                            {
                                var footballer = Mapper.Map<Footballer>(footballerData);
                                var isValidContract = DateTime.Compare(
                                    footballer.ContractStartDate,
                                    footballer.ContractEndDate) < 0;

                                if (isValidContract)
                                {
                                    coach.Footballers.Add(footballer);
                                }
                                else
                                {
                                    sb.AppendLine(ErrorMessage);
                                }
                            }
                            else
                            {
                                sb.AppendLine(ErrorMessage);
                            }
                        }

                        coaches.Add(coach);
                        sb.AppendLine(string.Format(
                            SuccessfullyImportedCoach,
                            coach.Name,
                            coach.Footballers.Count));
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                }

                context.Coaches.AddRange(coaches);
                context.SaveChanges();
            }

            return sb.ToString().Trim();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var teamsData = JsonConvert.DeserializeObject<List<TeamImportDto>>(jsonString);
            var sb = new StringBuilder();
            var teams = new List<Team>();

            foreach (var teamData in teamsData)
            {
                if (IsValid(teamData))
                {
                    var team = Mapper.Map<Team>(teamData);

                    foreach (var footballerId in teamData.Footballers)
                    {
                        if (context.Footballers.Any(x => x.Id == footballerId))
                        {
                            team.TeamsFootballers.Add(new TeamFootballer()
                            {
                                FootballerId = footballerId,
                                TeamId = team.Id,
                            });
                        }
                        else
                        {
                            sb.AppendLine(ErrorMessage);
                        }
                    }

                    teams.Add(team);
                    sb.AppendLine(string.Format(
                        SuccessfullyImportedTeam,
                        team.Name,
                        team.TeamsFootballers.Count));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Teams.AddRange(teams);
            context.SaveChanges();
            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}