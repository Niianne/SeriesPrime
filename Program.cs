using System;

namespace DIO.Series
{
    class Program
    {

        static SerieRepositório repositorio = new SerieRepositório();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    ListarSeries();
                    break;
                case "2":
                    InserirSeries();
                    break;
                case "3":
                    AtualizarSeries();
                    break;
                case "4":
                     ExcluirSeries();
                     break;
                case "5":
                    VisualizarSeries();
                    break;
                case "C":
                    Console.Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            opcaoUsuario = ObterOpcaoUsuario();
        }

        Console.WriteLine("Obrigada por utilizar nosso app!");
        Console.ReadLine();
    }

    private static void ExcluirSeries()
    {
        Console.Write("Insira o id da série: ");
        int indiceSeries = int.Parse(Console.ReadLine());

        repositorio.Exclui(indiceSeries);
    }

    private static void VisualizarSeries()
    {
        Console.Write("Insira o id da série: ");
        int indiceSeries = int.Parse(Console.ReadLine());

        var series = repositorio.RetornaPorId(indiceSeries);

        Console.WriteLine(series);
    }
    
    private static void AtualizarSeries()
    {
        Console.Write("Digite o id da série: ");
        int indiceSeries = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.Write("Insira o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Insira o titulo da série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Insira o Ano de lançamente da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Insira uma Breve Descrição da Série:");
        string entradaDescricao = Console.ReadLine();

        Series AtualizarSeries = new Series(id: indiceSeries,
                                        genero: (Genero)entradaGenero,
                                        Titulo: entradaTitulo,
                                        Ano: entradaAno,
                                        Descricao: entradaDescricao);

        repositorio.Atualiza(indiceSeries, AtualizarSeries);
    }

    
    private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada...");
                return;
            }
                foreach (var series in lista)
                {
                    var excluido = series.retonaExcluido();
                    
                    Console.WriteLine("#ID {0}: - {1} {2}", series.retornaId(), series.retornaTitulo(), (excluido ? "*Excluido!*" : ""));
                }
        }

        private static void InserirSeries()
    {
        Console.WriteLine("Insira a nova Série desejada: ");

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.Write("Insira o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Insira o Título da Série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Insira o Ano de lançamente da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Insira uma Breve Descrição da Série:");
        string entradaDescricao = Console.ReadLine();

        Series novaSerie = new Series(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        Titulo: entradaTitulo,
                                        Ano: entradaAno,
                                        Descricao: entradaDescricao);

        repositorio.Insere(novaSerie);
    }
    private static string ObterOpcaoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("Séries Prime");
        Console.WriteLine("Por Favor insira a opção desejada: ");
        
        Console.WriteLine("1- Listar séries");
        Console.WriteLine("2- Anexar nova série");
        Console.WriteLine("3- Atualizar alguma série desejada");
        Console.WriteLine("4- Excluir séries");
        Console.WriteLine("5- Visualizar série desejada");
        Console.WriteLine("C- Limpar Tela");
        Console.WriteLine("X- Sair");

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;
    }
    }
}
