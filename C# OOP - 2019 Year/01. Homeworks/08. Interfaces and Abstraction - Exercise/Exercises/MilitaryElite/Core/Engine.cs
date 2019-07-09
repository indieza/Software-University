namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private readonly List<Soldier> soldiers;
        private readonly CommandoFactory commandoFactory;
        private readonly EngineerFactory engineerFactory;
        private readonly LieutenantGeneralFactory lieutenantGeneralFactory;
        private readonly MissionFactory missionFactory;
        private readonly PrivateFactory privateFactory;
        private readonly RepairFactory repairFactory;
        private readonly SpyFactory spyFactory;

        public Engine()
        {
            this.soldiers = new List<Soldier>();
            this.commandoFactory = new CommandoFactory();
            this.engineerFactory = new EngineerFactory();
            this.lieutenantGeneralFactory = new LieutenantGeneralFactory();
            this.missionFactory = new MissionFactory();
            this.privateFactory = new PrivateFactory();
            this.repairFactory = new RepairFactory();
            this.spyFactory = new SpyFactory();
        }

        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] args = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = args[0];

                try
                {
                    switch (type)
                    {
                        case "Private":
                            Private privateSoldier = this.privateFactory.MakePrivateSoldier(args);
                            this.soldiers.Add(privateSoldier);
                            break;

                        case "LieutenantGeneral":
                            LieutenantGeneral lieutenantGeneral =
                                this.lieutenantGeneralFactory.MakeLieutenantGeneral(args);

                            for (int i = 5; i < args.Length; i++)
                            {
                                Private currentPrivate =
                                    (Private)this.soldiers.FirstOrDefault(p => p.Id == int.Parse(args[i]));

                                lieutenantGeneral.AddPrivate(currentPrivate);
                            }

                            this.soldiers.Add(lieutenantGeneral);

                            break;

                        case "Engineer":
                            Engineer engineer = this.engineerFactory.MakeEngineer(args);

                            for (int i = 6; i < args.Length; i += 2)
                            {
                                string name = args[i];
                                int hours = int.Parse(args[i + 1]);
                                Repair repair = this.repairFactory.MakeRepair(name, hours);
                                engineer.AddRepair(repair);
                            }

                            this.soldiers.Add(engineer);
                            break;

                        case "Commando":
                            Commando commando = this.commandoFactory.MakeCommando(args);

                            for (int i = 6; i < args.Length; i += 2)
                            {
                                string name = args[i];
                                string state = args[i + 1];

                                Mission mission = this.missionFactory.MakeMission(name, state);
                                commando.AddMission(mission);
                            }

                            this.soldiers.Add(commando);
                            break;

                        case "Spy":
                            Spy spy = this.spyFactory.MakeSpy(args);
                            this.soldiers.Add(spy);
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