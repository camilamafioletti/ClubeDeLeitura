﻿namespace ClubeDeLeitura.ConsoleApp
{
    public class AppService
    {
        public static void Mensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
