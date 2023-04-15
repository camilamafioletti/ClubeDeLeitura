using System.Collections;

namespace ClubeDeLeitura.ConsoleApp
{
    public class RepositorioEmprestimo
    {
        public static int contadorId = 1;
        public static ArrayList listaEmprestimos = new ArrayList();
        public static string statusAtual = "ABERTO";

        public static void InserirEmprestimo(Emprestimo emprestimo)
        {
            listaEmprestimos.Add(emprestimo);
        }

        public static void Criar(Emprestimo emprestimo)
        {
            InserirEmprestimo(emprestimo);
            contadorId++;
        }

        public static void Editar(int idEditar, Emprestimo emprestimoEditado)
        {
            Emprestimo emprestimo = SelecionarEmprestimoPorId(idEditar);

            emprestimo.amigoEmprestimo = emprestimoEditado.amigoEmprestimo;
            emprestimo.revistaEmprestada = emprestimoEditado.revistaEmprestada;
            emprestimo.dataEmprestimo = emprestimoEditado.dataEmprestimo;
            emprestimo.dataDevolutiva = emprestimoEditado.dataDevolutiva;
            //STATUS
        }

        public static void Deletar(int id)
        {
            Emprestimo emprestimo = SelecionarEmprestimoPorId(id);
            listaEmprestimos.Remove(emprestimo);
        }

        public static ArrayList SelecionarTodos()
        {
            return listaEmprestimos;
        }

        public static Emprestimo SelecionarEmprestimoPorId(int id)
        {
            Emprestimo emprestimo = null;

            foreach (Emprestimo a in listaEmprestimos)
            {
                if (a.id == id)
                {
                    emprestimo = a;
                    break;
                }
            }
            return emprestimo;
        }

        public static void FecharStatus(Emprestimo emprestimo)
        {
            emprestimo.status = "FECHADO";
        }
    }
}
