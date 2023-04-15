using System.Collections;

namespace ClubeDeLeitura.ConsoleApp.Compartilhado
{
    public class Repositorio
    {
        public static int contadorId = 0;
        public static ArrayList listaRegistros = new ArrayList();

        public void IncrementarId()
        {
            contadorId++;
        }

    }
}
