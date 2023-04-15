namespace ClubeDeLeitura.ConsoleApp
{
    public class Menu : AppService
    {
        public void MenuPrincipal()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("\n- Clube da Leitura do Gustavo -\n");

                Console.WriteLine("(1) Gerenciar empréstimos");
                Console.WriteLine("(2) Gerenciar revistas ");
                Console.WriteLine("(3) Gerenciar caixas");
                Console.WriteLine("(4) Gerenciar amigos");
                Console.WriteLine("(S) Sair ");

                string opcaoMenu = Console.ReadLine();


                if (opcaoMenu.ToUpper() == "S")
                {
                    Console.WriteLine("Saindo...");
                    break;
                }
                switch (opcaoMenu.ToUpper())
                {
                    case "1": MenuEmprestimo(); break;
                    case "2": MenuRevista(); break;
                    case "3": MenuCaixa(); break;
                    case "4": MenuAmigo(); break;

                    default: Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }

        }
        public void MenuAmigo()
        {
            while (true)
            {
                string opcaoMenu = TelaAmigo.ApresentarMenuAmigo();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando ao menu principal");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": TelaAmigo.InserirNovoAmigo(); break;
                    case "2": TelaAmigo.EditarAmigo(); break;
                    case "3": TelaAmigo.ListarAmigo(); break;
                    case "4": TelaAmigo.DeletarAmigo(); break;

                    default: Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }
        public void MenuCaixa()
        {
            while (true)
            {
                string opcaoMenu = TelaCaixa.ApresentarMenuCaixa();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando ao menu principal");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": TelaCaixa.InserirNovaCaixa(); break;
                    case "2": TelaCaixa.EditarCaixa(); break;
                    case "3": TelaCaixa.ListarCaixa(); break;
                    case "4": TelaCaixa.DeletarCaixa(); break;

                    default: Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }
        public void MenuRevista()
        {
            while (true)
            {
                string opcaoMenu = TelaRevista.ApresentarMenuRevista();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando ao menu principal");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": TelaRevista.InserirNovaRevista(); break;
                    case "2": TelaRevista.EditarRevista(); break;
                    case "3": TelaRevista.ListarRevistas(); break;
                    case "4": TelaRevista.DeletarRevista(); break;

                    default: Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }
        public void MenuEmprestimo()
        {
            while (true)
            {
                string opcaoMenu = TelaEmprestimo.ApresentarMenuEmprestimo();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando ao menu principal");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": TelaEmprestimo.InserirNovoEmprestimo(); break;
                    case "2": TelaEmprestimo.EditarEmprestimo(); break;
                    case "3": TelaEmprestimo.ListarEmprestimo(); break;
                    case "4": TelaEmprestimo.DeletarEmprestimo(); break;
                    case "5": TelaEmprestimo.AlterarStatus(); break;

                    default: Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }
    }
}
