using ClubeDeLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDeLeitura.ConsoleApp
{
    public class RepositorioRevista : Repositorio
    {
        
        public void InserirRevista(Revista revista)
        {
            listaRegistros.Add(revista);
        }

        public void Criar(Revista revista)
        {
            InserirRevista(revista);
            contadorId++;
        }

        public void Editar(int idEditar, Revista revistaEditada)
        {
            Revista revista = SelecionarRevistaPorId(idEditar);

            revista.ano = revistaEditada.ano;
            revista.edicao = revistaEditada.edicao;
            revista.colecao = revistaEditada.colecao;
            revista.caixa = revistaEditada.caixa;
        }

        public void Deletar(int id)
        {
            Revista revista = SelecionarRevistaPorId(id);
            listaRegistros.Remove(revista);
        }

        public ArrayList SelecionarTodos()
        {
            return listaRegistros;
        }

        public Revista SelecionarRevistaPorId(int id)
        {
            Revista revista = null;

            foreach (Revista a in listaRegistros)
            {
                if (a.id == id)
                {
                    revista = a;
                    break;
                }
            }
            return revista;
        }
    }
}
