using System;


namespace DIO.ESTOQUE
{
    class Program
    {
        static RepositorioPrato repositorio = new RepositorioPrato();
        static void Main(string[] args)
        {
						
            string opcaoUsuario = ObterOpcaoUsuario();

			    while (opcaoUsuario.ToUpper() != "X")
			{
				    switch (opcaoUsuario)
				{
					    case "1":
						    ListarPrato();
						    break;
					    case "2":
						    InserirPrato();
						    break;
					    case "3":
						    AtualizarPrato();
						    break;
					    case "4":
						    ExcluirPrato();
						    break;
					    case "5":
						    VisualizarPrato();
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

        private static void ExcluirPrato()
		{
			Console.Write("Digite o id do prato: ");
			int indicePrato = int.Parse(Console.ReadLine());

			repositorio.Exclui(indicePrato);
		}

        private static void VisualizarPrato()
		{
			Console.Write("Digite o id do prato: ");
			int indicePrato = int.Parse(Console.ReadLine());

			var prato = repositorio.RetornaPorId(indicePrato);

			Console.WriteLine(prato);
		}

        private static void AtualizarPrato()
		{
			Console.Write("Digite o id do prato: ");
			int indicePrato = int.Parse(Console.ReadLine());

			
			foreach (int i in Enum.GetValues(typeof(Categoria)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categoria), i));
			}
			Console.Write("Digite o categoria entre as opções acima: ");
			int entradaCategoria = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do Prato: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite a quantidade de pessoas servidas: ");
			int entradaQuantidadePessoasServidas = int.Parse(Console.ReadLine());

			Console.Write("Digite o preço: ");
			double   entradaPreco = double.Parse(Console.ReadLine());

			Prato atualizaPrato = new Prato(id: indicePrato,
										categoria: (Categoria)entradaCategoria,
										nome: entradaNome,
										quantidadePessoasServidas: entradaQuantidadePessoasServidas,
										preco: entradaPreco);

			repositorio.Atualiza(indicePrato, atualizaPrato);
		}
        private static void ListarPrato()
		{
			Console.WriteLine("Listar Pratos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Não existe prato cadastrado.");
				return;
			}

			foreach (var prato in lista)
			{
                var excluido = prato.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", prato.retornaId(), prato.retornaNome(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirPrato()
		{
			Console.WriteLine("Inserir novo Prato");

			
			foreach (int i in Enum.GetValues(typeof(Categoria)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categoria), i));
			}
			Console.Write("Digite a categoria entre as opções acima: ");
			int entradaCategoria = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do Prato: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite a quantidade de pessoas servidas: ");
			int entradaQuantidadePessoasServidas = int.Parse(Console.ReadLine());

			Console.Write("Digite o preço: ");
			double   entradaPreco = double.Parse(Console.ReadLine());

			Prato novoPrato = new Prato(id: repositorio.ProximoId(),
										categoria: (Categoria)entradaCategoria,
										nome: entradaNome,
										quantidadePessoasServidas: entradaQuantidadePessoasServidas,
										preco: entradaPreco);

			repositorio.Insere(novoPrato);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Restaurante Fome de Quê?");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Prato");
			Console.WriteLine("2- Inserir novo prato");
			Console.WriteLine("3- Atualizar prato");
			Console.WriteLine("4- Excluir prato");
			Console.WriteLine("5- Visualizar prato");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
