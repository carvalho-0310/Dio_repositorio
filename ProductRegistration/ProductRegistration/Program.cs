using ProductRegistration.Classes;

namespace ProductRegistration
{
    class Program
    {
        static ProdutoRepositorio repositorio = new ProdutoRepositorio();
        static void Main(string[] args)
        {
            String opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario) {
                    case "1":
                        ListProdutos();
                        break; 
                    case "2":
                        InsserirProsuto();
                        break;
                    case "3":
                        AtualizarProdutos();
                        break;   
                    case "4":
                        ExcluirProduto();
                        break; 
                    case "5":
                        VisualizarListaProdutos();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();                                     
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Fechando programa");
            Console.ReadLine();
        }
        private static void VisualizarListaProdutos()
        {
            Console.WriteLine("Digite o Id do produto que deve ser atualizado: ");
            int entradaId = int.Parse(Console.ReadLine());
            var produto = repositorio.RetonadoPorId(entradaId);

            Console.WriteLine(produto);
        }

        private static void ExcluirProduto()
        {
            Console.WriteLine("Digite o Id do produto que deve ser atualizado: ");
            int entradaId = int.Parse(Console.ReadLine());

            repositorio.Exclui(entradaId);
        }
        private static void AtualizarProdutos()
        {
            Console.WriteLine("Digite o Id do produto que deve ser atualizado: ");
            int entradaId = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome do produto:");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Quantos deste produto tem em estoque:");
            int entradaEstoque = int.Parse(Console.ReadLine().Replace(',', '.'));

            Console.WriteLine("Valor unitario desse produto:");
            double entradaValor = double.Parse(Console.ReadLine());

            Produtos novoProduto = new Produtos(entradaId
                , entradaNome
                , entradaEstoque
                , entradaValor);
            repositorio.Atualiza(entradaId,novoProduto);
        }
        private static void InsserirProsuto()
        {
            Console.WriteLine("Inserir novo produto");

            Console.WriteLine("Nome do produto:");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Quantos deste produto tem em estoque:");
            int entradaEstoque = int.Parse(Console.ReadLine());

            Console.WriteLine("Valor unitario desse produto:");
            double entradaValor = double.Parse(Console.ReadLine());

            Produtos novoProduto = new Produtos(repositorio.ProximoId()
                , entradaNome
                , entradaEstoque
                , entradaValor);
            repositorio.Insere(novoProduto);
        }
        private static void ListProdutos()
        {
            Console.WriteLine("Lista de produtos");

            var lista = repositorio.Lista();

            if (lista.Count == 0) {

                Console.WriteLine("Nenhum produtos cadastrado.");
                return;
            }
            foreach (var produto in lista) {
                var excluido = produto.retornaExcluido();
                Console.WriteLine("#ID {0}: {1} {2}" , produto.retornaId(), produto.retornaNome(), (excluido ? "Excluido" : ""));
            }
        }
        private static string ObterOpcaoUsuario() {
            Console.WriteLine();
            Console.WriteLine("Produtos disponíveis");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Lista de produtos");
            Console.WriteLine("2 - Inserir novo produto");
            Console.WriteLine("3 - Atualizar produtos");
            Console.WriteLine("4 - Excuir produto");
            Console.WriteLine("5 - Visualizar produto");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
