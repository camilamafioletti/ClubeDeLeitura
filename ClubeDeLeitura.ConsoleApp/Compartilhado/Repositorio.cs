using System.Collections;

namespace ClubeDeLeitura.ConsoleApp.Compartilhado
{
    public class Repositorio
    {
        public int contadorId = 4;
        public ArrayList listaRegistros = new ArrayList();

        public void IncrementarId()
        {
            contadorId++;
        }

    }
}
