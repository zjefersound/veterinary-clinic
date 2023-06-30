namespace VeterinaryClinic.Views
{
    public class Messages
    {
        public static void Error(string text)
        {
            Console.WriteLine($"\n[ERRO] {text}");
        }
        public static void Warn(string text)
        {
            Console.WriteLine($"\n[!] {text}");
        }
        public static void Success(string text)
        {
            Console.WriteLine($"\n[SUCESSO] {text}");
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
