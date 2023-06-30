namespace VeterinaryClinic.Views
{
    public class Menu
    {
        public static void PrintExit()
        {
            Console.WriteLine("(0) Sair do sistema");
        }

        public static void PrintGoBack()
        {
            Console.WriteLine("(0) Voltar");
        }

        public static void PrintOptions(List<string> options, bool exit = false)
        {
            if (exit)
                Menu.PrintExit();
            else
                Menu.PrintGoBack();
            foreach (var option in options.Select((title, index) => (title, index)))
            {
                Console.WriteLine($"({option.index + 1}) {option.title}");
            }
            Console.WriteLine("\n");
        }
    }
}
