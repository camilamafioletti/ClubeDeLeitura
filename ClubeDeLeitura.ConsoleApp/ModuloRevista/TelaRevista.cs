using System.Collections;

namespace ClubeDeLeitura.ConsoleApp
{
    public class TelaRevista : AppService
    {
        public static string ApresentarMenuRevista()
        {

            Console.Clear();

            Console.WriteLine("(1) Adicionar revista");
            Console.WriteLine("(2) Editar revista");
            Console.WriteLine("(3) Visualizar revistas");
            Console.WriteLine("(4) Excluir revista");
            Console.WriteLine("(V) Voltar ao menu ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;
        }

        public static void InserirNovaRevista() 
        {
            Revista novaRevista = ObterRevista();

            RepositorioRevista.Criar(novaRevista);

            Mensagem("Sucesso!", ConsoleColor.Green);
        }

        public static void EditarRevista()
        {
            int idSelecionado = ReceberIdRevista();

            foreach (Revista revista in RepositorioRevista.listaRevistas)
            {
                if (revista.id == idSelecionado)
                {
                    foreach (Caixa caixa in RepositorioCaixa.listaCaixas)
                    {
                        if (revista.caixa.id == caixa.id)
                        {
                            caixa.revistasNaCaixa.Remove(revista);
                        }
                    }
                }
            }
            
            Revista revistaAtualizada = ObterRevista();

            RepositorioRevista.Editar(idSelecionado, revistaAtualizada);

            Mensagem("Sucesso!", ConsoleColor.Green);
        }

        public static void ListarRevistas()
        {
            ArrayList listaRevista = RepositorioRevista.SelecionarTodos();

            Console.Clear();
            Console.WriteLine("Revistas registradas:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Colecao       |Edicao  |Ano   |Caixa   |");
            Console.WriteLine("---------------------------------------------");
            Console.ResetColor();

            if (listaRevista.Count == 0)
            {
                Mensagem("Nenhuma revista registrada!", ConsoleColor.DarkRed);
                return;
            }

            foreach (Revista revista in listaRevista)
            {
                Console.WriteLine("|{0,-3}|{1,-14}|{2,-8}|{3,-6}|{4,-8}|", revista.id ,revista.colecao, revista.edicao, revista.ano, revista.caixa.etiquetaCaixa);
            }

            Console.ReadKey();
        }

        public static void DeletarRevista()
        {
            int idSelecionado = ReceberIdRevista();
            RepositorioRevista.Deletar(idSelecionado);
            Mensagem("Revista excluída com sucesso!", ConsoleColor.Green);
        }

        public static int ReceberIdRevista()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id da revista: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = RepositorioRevista.SelecionarRevistaPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public static Revista ObterRevista()
        {
            Console.WriteLine("Informe o tipo da colecao: ");
            string tipoColecao = Console.ReadLine();

            Console.WriteLine("Informe o numero de edição: ");
            int numeroEdicao = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o ano: ");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o id da caixa: ");
            int idCaixa = int.Parse(Console.ReadLine());

            Caixa caixa = null;

            foreach (Caixa c in RepositorioCaixa.listaCaixas)
            {
                if (idCaixa == c.id)
                {
                    caixa = c;
                        
                }
            }
            while (caixa == null)
            {
                Mensagem("Caixa inexistente!", ConsoleColor.Red);
                Console.WriteLine("Digite o id da caixa que a revista pertence: ");
                idCaixa = int.Parse(Console.ReadLine());

                foreach (Caixa c in RepositorioCaixa.listaCaixas)
                {
                    if (idCaixa == c.id)
                    {
                        caixa = c;
                    }
                }
            }

            Revista revista = new Revista(RepositorioRevista.contadorId, caixa, tipoColecao, ano, numeroEdicao);

            return revista;
        }
    }
}
