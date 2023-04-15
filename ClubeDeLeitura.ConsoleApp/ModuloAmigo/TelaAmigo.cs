using System.Collections;

namespace ClubeDeLeitura.ConsoleApp
{
    public class TelaAmigo : AppService
    {
        public static string ApresentarMenuAmigo()
        {

            Console.Clear();

            Console.WriteLine("(1) Adicionar amigo");
            Console.WriteLine("(2) Editar amigo");
            Console.WriteLine("(3) Visualizar amigos");
            Console.WriteLine("(4) Excluir amigo");
            Console.WriteLine("(V) Voltar ao menu ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;

        }

        public static void InserirNovoAmigo()
        {
            Amigo novoAmigo = ObterAmigo();

            RepositorioAmigo.Criar(novoAmigo);

            Mensagem("Amigo criado com sucesso!", ConsoleColor.Green);
        }

        public static void EditarAmigo()
        {
            int idSelecionado = ReceberIdAmigo();
            Amigo amigoAtualizado = ObterAmigo();

            RepositorioAmigo.Editar(idSelecionado, amigoAtualizado);
            Mensagem("Sucesso!", ConsoleColor.Green);

        }

        public static void ListarAmigo()
        {
            ArrayList listaAmigos = RepositorioAmigo.SelecionarTodos();

            Console.Clear();
            Console.WriteLine("Amigos registrados:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Nome       |Responsável  |Telefone   |Endereço      |");
            Console.WriteLine("----------------------------------------------------------");
            Console.ResetColor();

            if (listaAmigos.Count == 0)
            {
                Mensagem("Nenhum amigo registrado!", ConsoleColor.DarkRed);
                return;
            }

            foreach (Amigo amigo in listaAmigos)
            {
                Console.WriteLine("|{0,-3}|{1,-11}|{2,-13}|{3,-11}|{4,-14}|", amigo.id, amigo.nome, amigo.nomeResponsavel, amigo.telefone,  amigo.endereco);
            }

            Console.ReadKey();
        }

        public static void DeletarAmigo()
        {
            int idSelecionado = ReceberIdAmigo();
            RepositorioAmigo.Deletar(idSelecionado);
            Mensagem("Revista excluída com sucesso!", ConsoleColor.Green);
        }

        public static int ReceberIdAmigo()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.WriteLine("Digite o id do amigo: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = RepositorioAmigo.SelecionarAmigoPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id Inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public static Amigo ObterAmigo()
        {
            Console.WriteLine("Informe o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Informe o nome do responsável: ");
            string responsavel = Console.ReadLine();

            Console.WriteLine("Informe o telefone do amigo: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Informe o endereço do amigo: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo(RepositorioAmigo.contadorId, nome, responsavel, telefone, endereco);

            return amigo;
        }
    }
}