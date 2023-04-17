using ClubeDeLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDeLeitura.ConsoleApp
{
    public class RepositorioEmprestimo : Repositorio
    {

        public string statusAtual = "ABERTO";

        public void InserirEmprestimo(Emprestimo emprestimo)
        {
            listaRegistros.Add(emprestimo);
        }

        public void Criar(Emprestimo emprestimo)
        {
            InserirEmprestimo(emprestimo);
            contadorId++;
        }

        public void Editar(int idEditar, Emprestimo emprestimoEditado)
        {
            Emprestimo emprestimo = SelecionarEmprestimoPorId(idEditar);

            emprestimo.amigoEmprestimo = emprestimoEditado.amigoEmprestimo;
            emprestimo.revistaEmprestada = emprestimoEditado.revistaEmprestada;
            emprestimo.dataEmprestimo = emprestimoEditado.dataEmprestimo;
            emprestimo.dataDevolutiva = emprestimoEditado.dataDevolutiva;

        }

        public void Deletar(int id)
        {
            Emprestimo emprestimo = SelecionarEmprestimoPorId(id);
            listaRegistros.Remove(emprestimo);
        }

        public ArrayList SelecionarTodos()
        {
            return listaRegistros;
        }

        public Emprestimo SelecionarEmprestimoPorId(int id)
        {
            Emprestimo emprestimo = null;

            foreach (Emprestimo a in listaRegistros)
            {
                if (a.id == id)
                {
                    emprestimo = a;
                    break;
                }
            }
            return emprestimo;
        }

        public void FecharStatus(Emprestimo emprestimo)
        {
            emprestimo.status = "FECHADO";
        }
    }
}
