using System.Collections;

namespace ClubeDeLeitura.ConsoleApp
{
    public class RepositorioRevista 
    {
        public static int contadorId = 4;
        public static ArrayList listaRevistas = new ArrayList();

        public static void InserirRevista(Revista revista)
        {
            listaRevistas.Add(revista);
        }

        public static void Criar(Revista revista)
        {
            InserirRevista(revista);
            contadorId++;
        }

        public static void Editar(int idEditar, Revista revistaEditada)
        {
            Revista revista = SelecionarRevistaPorId(idEditar);

            revista.ano = revistaEditada.ano;
            revista.edicao = revistaEditada.edicao;
            revista.colecao = revistaEditada.colecao;
            revista.caixa = revistaEditada.caixa;
        }
        public static void Deletar(int id)
        {
            Revista revista = SelecionarRevistaPorId(id);
            listaRevistas.Remove(revista);
        }
        public static ArrayList SelecionarTodos()
        {
            return listaRevistas;
        }

        public static Revista SelecionarRevistaPorId(int id)
        {
            Revista revista = null;

            foreach (Revista a in listaRevistas)
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
