namespace VeterinaryClinic.Views
{
    public class Messages
    {
        public static void Error(string text)
        {
            Console.WriteLine($"\n[!] {text}");
        }

        public static void Ops()
        {
            Messages.Error("Oooops");
        }

        public static void NeedsAction()
        {
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
