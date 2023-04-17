namespace ClubeDeLeitura.ConsoleApp
{
    public class Menu : AppService
    {

        public TelaCaixa telaCaixa = null;
        public TelaAmigo telaAmigo = null;
        public TelaEmprestimo telaEmprestimo = null;
        public TelaRevista telaRevista = null;

        public void MenuPrincipal()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("\n═══ CLUBE DA LEITURA ═════════\n");
                Console.WriteLine("(1) Gerenciar empréstimos");
                Console.WriteLine("(2) Gerenciar revistas ");
                Console.WriteLine("(3) Gerenciar caixas");
                Console.WriteLine("(4) Gerenciar amigos");
                Console.WriteLine("(S) Sair ");
                Console.Write("\nOpção:  ");

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
                string opcaoMenu = telaAmigo.ApresentarMenuAmigo();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando ao menu principal");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaAmigo.InserirNovoAmigo(); break;
                    case "2": telaAmigo.EditarAmigo(); break;
                    case "3": telaAmigo.ListarAmigo(); break;
                    case "4": telaAmigo.DeletarAmigo(); break;

                    default: Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }
        public void MenuCaixa()
        {
            while (true)
            {
                string opcaoMenu = telaCaixa.ApresentarMenuCaixa();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando ao menu principal");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaCaixa.InserirNovaCaixa(); break;
                    case "2": telaCaixa.EditarCaixa(); break;
                    case "3": telaCaixa.ListarCaixa(); break;
                    case "4": telaCaixa.DeletarCaixa(); break;

                    default: Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }
        public void MenuRevista()
        {
            while (true)
            {
                string opcaoMenu = telaRevista.ApresentarMenuRevista();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando ao menu principal");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaRevista.InserirNovaRevista(); break;
                    case "2": telaRevista.EditarRevista(); break;
                    case "3": telaRevista.ListarRevistas(); break;
                    case "4": telaRevista.DeletarRevista(); break;

                    default: Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }
        public void MenuEmprestimo()
        {
            while (true)
            {
                string opcaoMenu = telaEmprestimo.ApresentarMenuEmprestimo();

                if (opcaoMenu.ToUpper() == "V")
                {
                    Console.WriteLine("Voltando ao menu principal");
                    break;
                }

                switch (opcaoMenu.ToUpper())
                {
                    case "1": telaEmprestimo.InserirNovoEmprestimo(); break;
                    case "2": telaEmprestimo.EditarEmprestimo(); break;
                    case "3": telaEmprestimo.ListarEmprestimo(); break;
                    case "4": telaEmprestimo.DeletarEmprestimo(); break;
                    case "5": telaEmprestimo.AlterarStatus(); break;

                    default: Mensagem("\nopção inválida \n", ConsoleColor.Red); break;
                }
            }
        }
    }
}
