using System.Collections;

namespace ClubeDeLeitura.ConsoleApp
{
    public class RepositorioAmigo
    {
        public static int contadorId = 4;
        public static ArrayList listaAmigos = new ArrayList();

        public static void InserirAmigo(Amigo amigo)
        {
            listaAmigos.Add(amigo);
        }

        public static void Criar(Amigo amigo)
        {
            InserirAmigo(amigo);
            contadorId++;
        }

        public static void Editar(int idEditar, Amigo amigoEditado)
        {
            Amigo amigo = SelecionarAmigoPorId(idEditar);

            amigo.nome = amigoEditado.nome;
            amigo.nomeResponsavel = amigoEditado.nomeResponsavel;
            amigo.telefone = amigoEditado.telefone;
            amigo.endereco = amigoEditado.endereco;
        }

        public static void Deletar(int id)
        {
            Amigo amigo = SelecionarAmigoPorId(id);
            listaAmigos.Remove(amigo);
        }

        public static ArrayList SelecionarTodos()
        {
            return listaAmigos;
        }

        public static Amigo SelecionarAmigoPorId(int id)
        {
            Amigo amigo = null;

            foreach (Amigo a in listaAmigos)
            {
                if (a.id == id)
                {
                    amigo = a;
                    break;
                }
            }
            return amigo;
        }
    }
}
