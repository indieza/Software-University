namespace _01._Prototype
{
    public class StartUp
    {
        private static void Main()
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] =
                new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["RPB&J"] =
                new Sandwich("White", "", "", "Peanut Butter, Jelly");
            sandwichMenu["Turkey"] =
                new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

            sandwichMenu["LoadedBLT"] =
                new Sandwich("Wheat", "Turkey, Bacon", "American", "Lettuce, Tomato, Onion, Olives");
            sandwichMenu["ThreeMeatCombo"] =
                new Sandwich("Rye", "Turkey, Ham, Salami", "Provolone", "Lettuce, Onion");
            sandwichMenu["Vegetarian"] =
                new Sandwich("Wheat", "", "", "Lettuce, Onion, Tomato, Olives, Spinach");

            Sandwich sandwich1 = sandwichMenu["BLT"].Clone() as Sandwich;
            Sandwich sandwich2 = sandwichMenu["ThreeMeatCombo"].Clone() as Sandwich;
            Sandwich sandwich3 = sandwichMenu["Vegetarian"].Clone() as Sandwich;
        }
    }
}