using System.Collections;

namespace ClubeDeLeitura.ConsoleApp
{
    public class TelaEmprestimo : AppService
    {
        public RepositorioEmprestimo repositorioEmprestimo = null;
        public RepositorioAmigo repositorioAmigo = null;
        public RepositorioRevista repositorioRevista = null;

        public string ApresentarMenuEmprestimo()
        {

            Console.Clear();

            Console.WriteLine("(1) Adicionar empréstimo");
            Console.WriteLine("(2) Editar empréstimo");
            Console.WriteLine("(3) Visualizar empréstimo");
            Console.WriteLine("(4) Excluir empréstimo");
            Console.WriteLine("(5) Alterar status do empréstimo ");
            Console.WriteLine("(V) Voltar ao menu ");
            Console.Write("\nOpção:  ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;
        }

        public void InserirNovoEmprestimo()
        {
            Emprestimo novoEmprestimo = ObterEmprestimo();

            repositorioEmprestimo.Criar(novoEmprestimo);

            Mensagem("Sucesso!", ConsoleColor.Green);
        }

        public void EditarEmprestimo()
        {
            ListarEmprestimo();
            int idSelecionado = ReceberIdEmprestimo();
            Emprestimo emprestimoAtualizado = ObterEmprestimo();

            repositorioEmprestimo.Editar(idSelecionado, emprestimoAtualizado);

            Mensagem("Sucesso!", ConsoleColor.Green);
        }

        public void ListarEmprestimo()
        {
            ArrayList listaEmprestimo = repositorioEmprestimo.SelecionarTodos();

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

        public void DeletarEmprestimo()
        {
            ListarEmprestimo();
            int idSelecionado = ReceberIdEmprestimo();
            repositorioEmprestimo.Deletar(idSelecionado);
            Mensagem("Revista excluída com sucesso!", ConsoleColor.Green);
        }

        public int ReceberIdEmprestimo()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id do empréstimo: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = repositorioEmprestimo.SelecionarEmprestimoPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public Emprestimo ObterEmprestimo()
        {
            Amigo amigo = null;
            Revista revista = null;

            Console.Write("Informe o id do amigo que quer a revista: ");
            int idAmigo = int.Parse(Console.ReadLine());

            Console.Write("Informe o id da revista: ");
            int idRevista = int.Parse(Console.ReadLine());

            Console.Write("Informe a data do empréstimo: ");
            string dataDoEmprestimo = Console.ReadLine();

            Console.Write("Informe a data de devolução: ");
            string dataDevolucao = Console.ReadLine();


            foreach (Amigo a in repositorioAmigo.listaRegistros)
            {
                if (idAmigo == a.id)
                {
                    amigo = a;
                }
            }

            foreach (Revista r in repositorioRevista.listaRegistros)
            {
                if (idRevista == r.id)
                {
                    revista = r;
                }
            }

            Emprestimo emprestimo = new Emprestimo(repositorioEmprestimo.contadorId, revista, amigo, dataDoEmprestimo, dataDevolucao, repositorioEmprestimo.statusAtual);
            return emprestimo;
        }

        public void AlterarStatus()
        {
            ListarEmprestimo();
            int idFechar = ReceberIdEmprestimo();

            Emprestimo emprestimo = null;

            foreach (Emprestimo e in repositorioEmprestimo.listaRegistros)
            {
                if (idFechar == e.id)
                {
                    emprestimo = e;
                }
            }
            repositorioEmprestimo.FecharStatus(emprestimo);

            Mensagem("Sucesso!", ConsoleColor.Green);   
        }
    }
}
