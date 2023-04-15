using System.Collections;

namespace ClubeDeLeitura.ConsoleApp
{
    public class TelaEmprestimo : AppService
    {
        public static string ApresentarMenuEmprestimo()
        {

            Console.Clear();

            Console.WriteLine("(1) Adicionar empréstimo");
            Console.WriteLine("(2) Editar empréstimo");
            Console.WriteLine("(3) Visualizar empréstimo");
            Console.WriteLine("(4) Excluir empréstimo");
            Console.WriteLine("(5) Alterar status do empréstimo ");
            Console.WriteLine("(V) Voltar ao menu ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;
        }

        public static void InserirNovoEmprestimo()
        {
            Emprestimo novoEmprestimo = ObterEmprestimo();

            RepositorioEmprestimo.Criar(novoEmprestimo);

            Mensagem("Sucesso!", ConsoleColor.Green);
        }

        public static void EditarEmprestimo()
        {
            int idSelecionado = ReceberIdEmprestimo();
            Emprestimo emprestimoAtualizado = ObterEmprestimo();

            RepositorioEmprestimo.Editar(idSelecionado, emprestimoAtualizado);

            Mensagem("Sucesso!", ConsoleColor.Green);
        }

        public static void ListarEmprestimo()
        {
            ArrayList listaEmprestimo = RepositorioEmprestimo.SelecionarTodos();

            Console.Clear();
            Console.WriteLine("Empréstimos registrados:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Amigo       |Revista    |Data de Empréstimo  |Data de Devolução  |Status   |");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.ResetColor();

            if (listaEmprestimo.Count == 0)
            {
                Mensagem("Nenhum empréstimo registrado!", ConsoleColor.DarkRed);
                return;
            }

            foreach (Emprestimo emprestimo in listaEmprestimo)
            {
                Console.WriteLine("|{0,-3}|{1,-12}|{2,-11}|{3,-20}|{4,-19}|{5,-9}|", emprestimo.id, emprestimo.amigoEmprestimo.nome, emprestimo.revistaEmprestada.colecao, emprestimo.dataEmprestimo, emprestimo.dataDevolutiva, emprestimo.status);
            }
            Console.ReadKey();
        }

        public static void DeletarEmprestimo()
        {
            int idSelecionado = ReceberIdEmprestimo();
            RepositorioEmprestimo.Deletar(idSelecionado);
            Mensagem("Revista excluída com sucesso!", ConsoleColor.Green);
        }

        public static int ReceberIdEmprestimo()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id do empréstimo: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = RepositorioEmprestimo.SelecionarEmprestimoPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public static Emprestimo ObterEmprestimo()
        {
            Amigo amigo = null;
            Revista revista = null;

            Console.WriteLine("Informe o id do amigo que quer a revista: ");
            int idAmigo = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o id da revista: ");
            int idRevista = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe a data do empréstimo: ");
            string dataDoEmprestimo = Console.ReadLine();

            Console.WriteLine("Informe a data de devolução: ");
            string dataDevolucao = Console.ReadLine();

            foreach (Amigo a in RepositorioAmigo.listaAmigos)
            {
                if (idAmigo == a.id)
                {
                    amigo = a;
                }
            }

            foreach (Revista r in RepositorioRevista.listaRevistas)
            {
                if (idRevista == r.id)
                {
                    revista = r;
                }
            }

            Emprestimo emprestimo = new Emprestimo(RepositorioEmprestimo.contadorId, revista, amigo, dataDoEmprestimo, dataDevolucao, RepositorioEmprestimo.statusAtual);
            return emprestimo;
        }

        public static void AlterarStatus()
        {
            int idFechar = ReceberIdEmprestimo();

            Emprestimo emprestimo = null;

            foreach (Emprestimo e in RepositorioEmprestimo.listaEmprestimos)
            {
                if (idFechar == e.id)
                {
                    emprestimo = e;
                }
            }
            RepositorioEmprestimo.FecharStatus(emprestimo);
        }
    }
}
