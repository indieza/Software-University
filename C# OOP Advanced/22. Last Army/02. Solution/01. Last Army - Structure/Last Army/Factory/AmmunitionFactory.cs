public class AmmunitionFactory
{
    public static IAmmunition CreateAmmunition(string name)
    {
        switch (name)
        {
            case "Helmet":
                return new Helmet(name);

            case "Knife":
                return new Knife(name);

            case "NightVision":
                return new NightVision(name);

            case "AutomaticMachine":
                return new AutomaticMachine(name);

            case "Gun":
                return new Gun(name);

            case "MachineGun":
                return new MachineGun(name);
        }

        return new RPG(name);
    }
}