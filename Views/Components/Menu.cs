namespace VeterinaryClinic.Views
{
    public class Menu
    {
        public static void PrintExit()
        {
            Console.WriteLine("(0) Sair");
        }

        public static void PrintOptions(List<string> options)
        {
            Menu.PrintExit();
            foreach (var option in options.Select((title, index) => (title, index)))
            {
                Console.WriteLine($"({option.index + 1}) {option.title}");
            }
            Console.WriteLine("\n");
        }
    }
}
