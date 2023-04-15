using System.Collections;

namespace ClubeDeLeitura.ConsoleApp
{
    public class Caixa : Entidade
    {
        
        public int numero;
        public string corCaixa;
        public string etiquetaCaixa;
        public ArrayList revistasNaCaixa = new ArrayList();

        public Caixa(int id, int numero, string corCaixa, string etiquetaCaixa)
        {
            this.id = id;
            this.numero = numero;
            this.corCaixa = corCaixa;
            this.etiquetaCaixa = etiquetaCaixa;
        }
    }
}
