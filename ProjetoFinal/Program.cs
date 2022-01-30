using System;

namespace DIO.Series
{
    class Program
    {
        static HistoriaRepositorio repositorio = new HistoriaRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarHistoria();
						break;
					case "2":
						InserirHistoria();
						break;
					case "3":
						AtualizarHistoria();
						break;
					case "4":
						ExcluirHistoria();
						break;
					case "5":
						VisualizarHistoria();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirHistoria()
		{
			Console.Write("Digite o id da Historia: ");
			int indiceHistoria = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceHistoria);
		}

        private static void VisualizarHistoria()
		{
			Console.Write("Digite o id da Historia: ");
			int indiceHistoria = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceHistoria);

			Console.WriteLine(serie);
		}

        private static void AtualizarHistoria()
		{
			Console.Write("Digite o id da Historia: ");
			int indiceHistoria = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Historia atualizaHistoria = new Historia(id: indiceHistoria,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceHistoria, atualizaHistoria);
		}
        private static void ListarHistoria()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma Historia cadastrada.");
				return;
			}

			foreach (var Historia in lista)
			{
                var excluido = Historia.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", Historia.retornaId(), Historia.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirHistoria()
		{
			Console.WriteLine("Inserir nova Historia");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Historia: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início de inicio da Historia: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da historia: ");
			string entradaDescricao = Console.ReadLine();

			Historia novaHistoria = new Historia(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaHistoria);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Historia");
			Console.WriteLine("2- Inserir nova Historia");
			Console.WriteLine("3- Atualizar Historia");
			Console.WriteLine("4- Excluir historia");
			Console.WriteLine("5- Visualizar Historia");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
