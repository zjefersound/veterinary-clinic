namespace VeterinaryClinic.Views
{
    public class Menu
    {
        public static void PrintOptions(List<string> options)
        {
            Console.WriteLine("(0) Sair");
            foreach (var option in options.Select((title, index) => (title, index)))
            {
                Console.WriteLine($"({option.index + 1}) {option.title}");
            }
            Console.WriteLine("\n");
        }
    }
}
