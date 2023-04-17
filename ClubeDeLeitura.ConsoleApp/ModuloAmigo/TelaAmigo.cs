using System.Collections;

namespace ClubeDeLeitura.ConsoleApp
{
    public class TelaAmigo : AppService
    {

        public RepositorioAmigo repositorioAmigo = null; 

        public string ApresentarMenuAmigo()
        {

            Console.Clear();

            Console.WriteLine("(1) Adicionar amigo");
            Console.WriteLine("(2) Editar amigo");
            Console.WriteLine("(3) Visualizar amigos");
            Console.WriteLine("(4) Excluir amigo");
            Console.WriteLine("(V) Voltar ao menu ");
            Console.Write("\nOpção:  ");

            string opcaoMenu = Console.ReadLine();

            return opcaoMenu;

        }

        public void InserirNovoAmigo()
        {
            Amigo novoAmigo = ObterAmigo();

            repositorioAmigo.Criar(novoAmigo);

            Mensagem("Amigo criado com sucesso!", ConsoleColor.Green);
        }

        public void EditarAmigo()
        {
            ListarAmigo();
            int idSelecionado = ReceberIdAmigo();
            Amigo amigoAtualizado = ObterAmigo();

            repositorioAmigo.Editar(idSelecionado, amigoAtualizado);
            Mensagem("Sucesso!", ConsoleColor.Green);

        }

        public void ListarAmigo()
        {
            ArrayList listaAmigos = repositorioAmigo.SelecionarTodos();

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

        public void DeletarAmigo()
        {
            ListarAmigo();
            int idSelecionado = ReceberIdAmigo();
            repositorioAmigo.Deletar(idSelecionado);
            Mensagem("Revista excluída com sucesso!", ConsoleColor.Green);
        }

        public int ReceberIdAmigo()
        {
            bool idInvalido;
            int id;
            do
            {
                Console.Write("Digite o id do amigo: ");
                id = int.Parse(Console.ReadLine());

                idInvalido = repositorioAmigo.SelecionarAmigoPorId(id) == null;

                if (idInvalido)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("id Inválido, tente novamente");
                    Console.ResetColor();
                }
            } while (idInvalido);

            return id;
        }

        public Amigo ObterAmigo()
        {
            Console.Write("Informe o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o nome do responsável: ");
            string responsavel = Console.ReadLine();

            Console.Write("Informe o telefone do amigo: ");
            string telefone = Console.ReadLine();

            Console.Write("Informe o endereço do amigo: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo(repositorioAmigo.contadorId, nome, responsavel, telefone, endereco);

            return amigo;
        }
    }
}