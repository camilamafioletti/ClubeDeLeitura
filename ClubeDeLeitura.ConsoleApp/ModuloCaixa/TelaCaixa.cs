using System.Collections;

namespace ClubeDeLeitura.ConsoleApp
{
    public class TelaCaixa : AppService
    {
        public static string ApresentarMenuCaixa()
        {

            Console.Clear();

            Console.WriteLine("(1) Adicionar caixa");
            Console.WriteLine("(2) Editar caixa");
            Console.WriteLine("(3) Visualizar caixas");
            Console.WriteLine("(4) Excluir caixa");
            Console.WriteLine("(V) Voltar ao menu ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;
        }

        public static void InserirNovaCaixa()
        {
            Caixa novaCaixa = ObterCaixa();

            RepositorioCaixa.Criar(novaCaixa);

            Mensagem("Sucesso!", ConsoleColor.Green);
        }

        public static void EditarCaixa()
        {
            int idSelecionado = ReceberIdCaixa();
            Caixa caixaAtualizada = ObterCaixa();

            RepositorioCaixa.Editar(idSelecionado, caixaAtualizada);
            Mensagem("Sucesso!", ConsoleColor.Green);
        }

        public static void ListarCaixa()
        {
            ArrayList listaCaixa = RepositorioCaixa.SelecionarTodos();

            Console.Clear();
            Console.WriteLine("Caixas registradas:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Cor       |Etiqueta  |Numero|");
            Console.WriteLine("----------------------------------");
            Console.ResetColor();

            if (listaCaixa.Count == 0)
            {
                Mensagem("Nenhuma caixa registrada!", ConsoleColor.DarkRed);
                return;
            }

            foreach (Caixa caixa in listaCaixa)
            {
                Console.WriteLine("|{0,-3}|{1,-10}|{2,-10}|{3,-6}|", caixa.id, caixa.corCaixa, caixa.etiquetaCaixa, caixa.numero);
            }

            Console.ReadKey();
        }

        public static void DeletarCaixa()
        {
            int idSelecionado = ReceberIdCaixa();
            RepositorioCaixa.Deletar(idSelecionado);
            Mensagem("Caixa excluída com sucesso!", ConsoleColor.Green);
        }

        public static int ReceberIdCaixa()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id da caixa: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = RepositorioCaixa.SelecionarCaixaPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id Inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public static Caixa ObterCaixa()
        {
            Console.WriteLine("Informe a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.WriteLine("Informe a etiqueta: ");
            string etiqueta = Console.ReadLine();

            Console.WriteLine("Informe o numero: ");
            int numero = int.Parse(Console.ReadLine());

            Caixa caixa = new Caixa(RepositorioCaixa.contadorId, numero, cor, etiqueta);

            return caixa;
        }

    }
}
