using ClubeDeLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDeLeitura.ConsoleApp
{
    public class RepositorioCaixa : Repositorio
    {
        
        public void InserirCaixa(Caixa caixa)
        {
            listaRegistros.Add(caixa);
        }

        public void Criar(Caixa caixa)
        {
            InserirCaixa(caixa);
            contadorId++;
        }

        public void Editar(int idEditar, Caixa caixaEditada)
        {
            Caixa caixa = SelecionarCaixaPorId(idEditar);

            caixa.etiquetaCaixa = caixaEditada.etiquetaCaixa;
            caixa.numero = caixaEditada.numero;
            caixa.corCaixa = caixaEditada.corCaixa; 
        }

        public void Deletar(int id)
        {
            Caixa caixa = SelecionarCaixaPorId(id);
            listaRegistros.Remove(caixa);
        }

        public ArrayList SelecionarTodos()
        {
            return listaRegistros;
        }

        public Caixa SelecionarCaixaPorId(int id)
        {
            Caixa caixa = null;

            foreach (Caixa a in listaRegistros)
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
