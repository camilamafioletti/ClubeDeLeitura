using ClubeDeLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDeLeitura.ConsoleApp
{
    public class RepositorioCaixa 
    {
        public static int contadorId = 4;
        public static ArrayList listaCaixas = new ArrayList();

        public static void InserirCaixa(Caixa caixa)
        {
            listaCaixas.Add(caixa);
        }

        public static void Criar(Caixa caixa)
        {
            InserirCaixa(caixa);
            contadorId++;
        }

        public static void Editar(int idEditar, Caixa caixaEditada)
        {
            Caixa caixa = SelecionarCaixaPorId(idEditar);

            caixa.etiquetaCaixa = caixaEditada.etiquetaCaixa;
            caixa.numero = caixaEditada.numero;
            caixa.corCaixa = caixaEditada.corCaixa; 
        }

        public static void Deletar(int id)
        {
            Caixa caixa = SelecionarCaixaPorId(id);
            listaCaixas.Remove(caixa);
        }

        public static ArrayList SelecionarTodos()
        {
            return listaCaixas;
        }

        public static Caixa SelecionarCaixaPorId(int id)
        {
            Caixa caixa = null;

            foreach (Caixa a in listaCaixas)
            {
                if (a.id == id)
                {
                    caixa = a;
                    break;
                }
            }
            return caixa;
        }
    }
}
