namespace ClubeDeLeitura.ConsoleApp
{
    public class Emprestimo : Entidade
    {
      
        public Revista revistaEmprestada;
        public Amigo amigoEmprestimo;
        public string dataEmprestimo;
        public string dataDevolutiva;
        public string status;

        public Emprestimo(int id, Revista revistaEmprestada, Amigo amigoEmprestimo, string dataEmprestimo, string dataDevolutiva, string status)
        {
            this.id = id;
            this.revistaEmprestada = revistaEmprestada;
            this.amigoEmprestimo = amigoEmprestimo;
            this.dataEmprestimo = dataEmprestimo;
            this.dataDevolutiva = dataDevolutiva;
            this.status = status;   
        }
    }
}
