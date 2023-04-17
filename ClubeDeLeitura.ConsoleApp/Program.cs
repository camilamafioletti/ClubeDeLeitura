namespace ClubeDeLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioRevista repositorioRevista = new RepositorioRevista();
            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();

            TelaAmigo telaAmigo = new TelaAmigo();
            TelaCaixa telaCaixa = new TelaCaixa();
            TelaRevista telaRevista = new TelaRevista();
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo();

            Menu menu = new Menu();

            menu.telaRevista = telaRevista;
            menu.telaCaixa = telaCaixa;
            menu.telaEmprestimo = telaEmprestimo;
            menu.telaAmigo = telaAmigo;


            telaAmigo.repositorioAmigo = repositorioAmigo;
            
            telaCaixa.repositorioCaixa = repositorioCaixa;
            
            telaRevista.repositorioRevista = repositorioRevista;
            telaRevista.repositorioCaixa = repositorioCaixa;
            
            telaEmprestimo.repositorioEmprestimo = repositorioEmprestimo;
            telaEmprestimo.repositorioAmigo = repositorioAmigo;
            telaEmprestimo.repositorioRevista = repositorioRevista;


            #region
            //Caixas
            Caixa caixa00 = new Caixa(0, 01, "Azul", "Ação");
            Caixa caixa01 = new Caixa(1, 02, "Rosa", "Aventura");
            Caixa caixa02 = new Caixa(2, 03, "Amarelo", "infantil");
            Caixa caixa03 = new Caixa(3, 04, "Verde", "Heroi");

            repositorioCaixa.listaRegistros.Add(caixa00);
            repositorioCaixa.listaRegistros.Add(caixa01);
            repositorioCaixa.listaRegistros.Add(caixa02);
            repositorioCaixa.listaRegistros.Add(caixa03);

            //Amigos
            Amigo amigo00 = new Amigo(0, "Gabi", "Julia", "9952-2451", "Rua Inter");
            Amigo amigo01 = new Amigo(1, "Marina", "Selma", "9851-2684", "Rua Vasco");
            Amigo amigo02 = new Amigo(2, "Juquinha", "Jorge", "9928-3130", "Rua Gremio");
            Amigo amigo03 = new Amigo(3, "Marquinhos", "Joana", "9900-9557", "Rua Flamengo");

            repositorioAmigo.listaRegistros.Add(amigo00);
            repositorioAmigo.listaRegistros.Add(amigo01);
            repositorioAmigo.listaRegistros.Add(amigo02);
            repositorioAmigo.listaRegistros.Add(amigo03);

            //Revistas
            Revista revista00 = new Revista(0, caixa03, "Batman", 2006, 10);
            Revista revista01 = new Revista(1, caixa03, "Hulk", 2002, 15);
            Revista revista02 = new Revista(2, caixa02, "Monica", 2010, 20);
            Revista revista03 = new Revista(3, caixa02, "Superman", 2015, 30);

            repositorioRevista.listaRegistros.Add(revista00);
            repositorioRevista.listaRegistros.Add(revista01);
            repositorioRevista.listaRegistros.Add(revista02);
            repositorioRevista.listaRegistros.Add(revista03);

            //Emprestimo
            repositorioEmprestimo.listaRegistros.Add(new Emprestimo(0, revista00, amigo00, "24/01/2023", "26/02/2023", "ABERTO"));
            repositorioEmprestimo.listaRegistros.Add(new Emprestimo(1, revista01, amigo01, "01/01/2023", "06/02/2023", "ABERTO"));
            repositorioEmprestimo.listaRegistros.Add(new Emprestimo(2, revista02, amigo02, "05/01/2023", "11/02/2023", "ABERTO"));
            repositorioEmprestimo.listaRegistros.Add(new Emprestimo(3, revista03, amigo03, "08/01/2023", "15/02/2023", "ABERTO"));
            #endregion

            menu.MenuPrincipal();

           
        }
    }
}
