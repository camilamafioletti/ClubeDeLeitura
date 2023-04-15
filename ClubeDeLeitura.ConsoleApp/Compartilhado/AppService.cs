namespace ClubeDeLeitura.ConsoleApp
{
    public class AppService
    {
        public static void Mensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            //Thread.Sleep(3000);
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
