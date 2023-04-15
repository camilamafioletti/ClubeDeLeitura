using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ClubeDeLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            //Caixas
            Caixa caixa00 = new Caixa(0, 01, "Azul", "Ação");

            RepositorioCaixa.listaCaixas.Add(caixa00);
            RepositorioCaixa.listaCaixas.Add(new Caixa(1, 02, "Rosa", "Aventura"));
            RepositorioCaixa.listaCaixas.Add(new Caixa(2, 03, "Amarelo", "infantil"));
            RepositorioCaixa.listaCaixas.Add(new Caixa(3, 04, "Verde", "Heroi"));

            //Amigos
            Amigo amigo00 = new Amigo(0, "Gabi", "Julia", "9952-2451", "Rua Inter");

            RepositorioAmigo.listaAmigos.Add(amigo00);
            RepositorioAmigo.listaAmigos.Add(new Amigo(1, "Marina", "Selma", "9851-2684", "Rua Vasco"));
            RepositorioAmigo.listaAmigos.Add(new Amigo(2, "Juquinha", "Jorge", "9928-3130", "Rua Gremio"));
            RepositorioAmigo.listaAmigos.Add(new Amigo(3, "Marquinhos", "Joana", "9900-9557", "Rua Flamengo"));

            //Revistas
            Revista revista00 = new Revista(0, caixa00, "Batman", 2006, 10);

            RepositorioRevista.listaRevistas.Add(revista00);
            RepositorioRevista.listaRevistas.Add(new Revista(1, caixa00, "Hulk", 2006, 10));
            RepositorioRevista.listaRevistas.Add(new Revista(2, caixa00, "Monica", 2006, 20));
            RepositorioRevista.listaRevistas.Add(new Revista(3, caixa00, "Superman", 2006, 30));

            //Emprestimo
            RepositorioEmprestimo.listaEmprestimos.Add(new Emprestimo(0, revista00, amigo00, "24/01/2023", "26/02/2023", "EM ABERTO"));

            Menu menu = new Menu();

            menu.MenuPrincipal();
            
        }
    }
}
