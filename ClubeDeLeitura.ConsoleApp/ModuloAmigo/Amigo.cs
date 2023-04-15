namespace ClubeDeLeitura.ConsoleApp
{
    public class Amigo : Entidade
    {
        
        public string nome;
        public string nomeResponsavel;
        public string telefone;
        public string endereco;

        public Amigo(int id, string nome, string nomeResponsavel, string telefone, string endereco)
        {
            this.id = id;
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.telefone = telefone;
            this.endereco = endereco;
        }
    }
}
