using ClubeDeLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDeLeitura.ConsoleApp
{
    public class RepositorioAmigo : Repositorio
    {

        public void InserirAmigo(Amigo amigo)
        {
            listaRegistros.Add(amigo);
        }

        public void Criar(Amigo amigo)
        {
            InserirAmigo(amigo);
            contadorId++;
        }

        public void Editar(int idEditar, Amigo amigoEditado)
        {
            Amigo amigo = SelecionarAmigoPorId(idEditar);

            amigo.nome = amigoEditado.nome;
            amigo.nomeResponsavel = amigoEditado.nomeResponsavel;
            amigo.telefone = amigoEditado.telefone;
            amigo.endereco = amigoEditado.endereco;
        }

        public void Deletar(int id)
        {
            Amigo amigo = SelecionarAmigoPorId(id);
            listaRegistros.Remove(amigo);
        }

        public ArrayList SelecionarTodos()
        {
            return listaRegistros;
        }

        public Amigo SelecionarAmigoPorId(int id)
        {
            Amigo amigo = null;

            foreach (Amigo a in listaRegistros)
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
