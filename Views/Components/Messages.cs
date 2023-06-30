namespace VeterinaryClinic.Views
{
    public class Messages
    {
        public static void Error(string text)
        {
            Console.WriteLine($"\n[ERRO] {text}");
            Messages.NeedsAction();
        }
        public static void Warn(string text)
        {
            Console.WriteLine($"\n[!] {text}");
            Messages.NeedsAction();
        }
        public static void Success(string text)
        {
            Console.WriteLine($"\n[SUCESSO] {text}");
            Messages.NeedsAction();
        }

        public static void Ops()
        {
            Messages.Error("Oooops");
        }

        public static void NeedsAction()
        {
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
