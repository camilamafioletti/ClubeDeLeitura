using System.Collections;

namespace ClubeDeLeitura.ConsoleApp
{
    public class TelaCaixa : AppService
    {
        public RepositorioCaixa repositorioCaixa = null;

        public string ApresentarMenuCaixa()
        {

            Console.Clear();

            Console.WriteLine("(1) Adicionar caixa");
            Console.WriteLine("(2) Editar caixa");
            Console.WriteLine("(3) Visualizar caixas");
            Console.WriteLine("(4) Excluir caixa");
            Console.WriteLine("(V) Voltar ao menu ");
            Console.Write("\nOpção:  ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;
        }

        public void InserirNovaCaixa()
        {
            Caixa novaCaixa = ObterCaixa();

            repositorioCaixa.Criar(novaCaixa);

            Mensagem("Sucesso!", ConsoleColor.Green);
        }

        public void EditarCaixa()
        {
            ListarCaixa();
            int idSelecionado = ReceberIdCaixa();
            Caixa caixaAtualizada = ObterCaixa();

            repositorioCaixa.Editar(idSelecionado, caixaAtualizada);
            Mensagem("Sucesso!", ConsoleColor.Green);
        }

        public void ListarCaixa()
        {
            ArrayList listaCaixa = repositorioCaixa.SelecionarTodos();

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

        public void DeletarCaixa()
        {
            ListarCaixa();
            int idSelecionado = ReceberIdCaixa();
            repositorioCaixa.Deletar(idSelecionado);
            Mensagem("Caixa excluída com sucesso!", ConsoleColor.Green);
        }

        public int ReceberIdCaixa()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.Write("Digite o id da caixa: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = repositorioCaixa.SelecionarCaixaPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id Inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public Caixa ObterCaixa()
        {
            Console.Write("Informe a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.Write("Informe a etiqueta: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Informe o numero: ");
            int numero = int.Parse(Console.ReadLine());

            Caixa caixa = new Caixa(repositorioCaixa.contadorId, numero, cor, etiqueta);

            return caixa;
        }

    }
}
