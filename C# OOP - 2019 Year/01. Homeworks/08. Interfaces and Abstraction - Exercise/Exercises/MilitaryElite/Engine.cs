namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private readonly List<Soldier> soldiers;
        private readonly PrivateFactory privateFactory;
        private readonly CommandoFactory commandoFactory;
        private readonly MissionFactory missionFactory;
        private readonly SpyFactory spyFactory;
        private readonly LieutenantGeneralFactory lieutenantGeneralFactory;
        private readonly EngineerFactory engineerFactory;
        private readonly RepairFactory repairFactory;

        public Engine()
        {
            this.soldiers = new List<Soldier>();
            this.privateFactory = new PrivateFactory();
            this.commandoFactory = new CommandoFactory();
            this.missionFactory = new MissionFactory();
            this.spyFactory = new SpyFactory();
            this.lieutenantGeneralFactory = new LieutenantGeneralFactory();
            this.engineerFactory = new EngineerFactory();
            this.repairFactory = new RepairFactory();
        }

        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "End")
            {
                try
                {
                    string[] args = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string type = args[0];

                    switch (type)
                    {
                        case "Private":
                            Private privateSoldier = this.privateFactory.CreatePrivate(args);
                            this.soldiers.Add(privateSoldier);
                            break;

                        case "LieutenantGeneral":
                            LieutenantGeneral lieutenantGeneralSoldire =
                                this.lieutenantGeneralFactory.CreateLieutenantGeneral(args);

                            for (int i = 5; i < args.Length; i++)
                            {
                                Private item =
                                    (Private)this.soldiers.FirstOrDefault(x => x.Id == int.Parse(args[i]));
                                lieutenantGeneralSoldire.AddPrivate(item);
                            }

                            this.soldiers.Add(lieutenantGeneralSoldire);
                            break;

                        case "Engineer":
                            Engineer engineerSoldier = this.engineerFactory.CreateEngineer(args);

                            for (int i = 6; i < args.Length; i += 2)
                            {
                                string part = args[i];
                                int hours = int.Parse(args[i + 1]);
                                Repair repair = this.repairFactory.CreateRepair(part, hours);
                                engineerSoldier.AddRepair(repair);
                            }

                            this.soldiers.Add(engineerSoldier);
                            break;

                        case "Commando":
                            Commando commandoSoldire = this.commandoFactory.CreateCommando(args);

                            for (int i = 6; i < args.Length; i += 2)
                            {
                                string codeName = args[i];
                                string state = args[i + 1];
                                Mission mission = this.missionFactory.CreateMission(codeName, state);
                                commandoSoldire.AddMission(mission);
                            }

                            this.soldiers.Add(commandoSoldire);
                            break;

                        case "Spy":
                            Spy spySoldier = this.spyFactory.CreateSpy(args);
                            this.soldiers.Add(spySoldier);
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                }

                line = Console.ReadLine();
            }

            foreach (var soldier in this.soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}