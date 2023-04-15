namespace ClubeDeLeitura.ConsoleApp
{
    public class Revista : Entidade
    {
        public Caixa caixa;
        public string colecao;
        public int ano;
        public int edicao;

        public Revista(int id, Caixa caixa, string colecao, int ano, int edicao)
        {
            this.id = id;
            this.caixa = caixa;
            this.colecao = colecao;
            this.ano = ano;
            this.edicao = edicao;
        }
    }
}
