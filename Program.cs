using System.Text;
using TrabalhoPOOPolimorfismo.Domain.Application;
using TrabalhoPOOPolimorfismo.Domain.Services;
using TrabalhoPOOPolimorfismo.Domain.Entities;
using TrabalhoPOOPolimorfismo.Domain.Infra;

Console.OutputEncoding = Encoding.UTF8;

var estoqueService = new EstoqueService(new RepositorioProdutoInMemory());

ExecutarMenu();

void ExecutarMenu()
{
    bool executando = true;

    while (executando)
    {
        ExibirMenuPrincipal();
        var opcao = Console.ReadLine() ?? "0";

        switch (opcao)
        {
            case "1":
                MenuProdutos();
                break;
            case "2":
                MenuRelatorios();
                break;
            case "0":
                executando = false;
                Console.WriteLine("\nAté logo!");
                break;
            default:
                Console.WriteLine("\nOpção inválida. Tente novamente.");
                break;
        }

        if (executando)
        {
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

void ExibirMenuPrincipal()
{
    Console.Clear();
    Console.WriteLine("╔════════════════════════════════════════╗");
    Console.WriteLine("║      SISTEMA DE CONTROLE DE ESTOQUE     ║");
    Console.WriteLine("╚════════════════════════════════════════╝");
    Console.WriteLine("1 - Produtos");
    Console.WriteLine("2 - Relatórios");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");
}

void MenuProdutos()
{
    bool voltarAoMenu = false;

    while (!voltarAoMenu)
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║             MENU DE PRODUTOS            ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.WriteLine("1 - Cadastrar produto perecível");
        Console.WriteLine("2 - Cadastrar produto eletrônico");
        Console.WriteLine("3 - Cadastrar produto de limpeza");
        Console.WriteLine("4 - Cadastrar produto controlado");
        Console.WriteLine("5 - Listar produtos");
        Console.WriteLine("0 - Voltar ao menu principal");
        Console.Write("Escolha uma opção: ");

        var opcao = Console.ReadLine() ?? "0";

        switch (opcao)
        {
            case "1":
                CadastrarProdutoPerecivel();
                break;
            case "2":
                CadastrarProdutoEletronico();
                break;
            case "3":
                CadastrarProdutoLimpeza();
                break;
            case "4":
                CadastrarProdutoControlado();
                break;
            case "5":
                ListarProdutos();
                break;
            case "0":
                voltarAoMenu = true;
                break;
            default:
                Console.WriteLine("\nOpção inválida. Tente novamente.");
                break;
        }

        if (!voltarAoMenu)
        {
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

void MenuRelatorios()
{
    bool voltarAoMenu = false;

    while (!voltarAoMenu)
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║            MENU DE RELATÓRIOS           ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.WriteLine("1 - Exibir relatório de estoque");
        Console.WriteLine("0 - Voltar ao menu principal");
        Console.Write("Escolha uma opção: ");

        var opcao = Console.ReadLine() ?? "0";

        switch (opcao)
        {
            case "1":
                ExibirRelatorio();
                break;
            case "0":
                voltarAoMenu = true;
                break;
            default:
                Console.WriteLine("\nOpção inválida. Tente novamente.");
                break;
        }

        if (!voltarAoMenu)
        {
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

void CadastrarProdutoPerecivel()
{
    Console.Clear();
    Console.WriteLine("╔════════════════════════════════════════╗");
    Console.WriteLine("║       CADASTRAR PRODUTO PERECÍVEL      ║");
    Console.WriteLine("╚════════════════════════════════════════╝");
    Console.Write("Nome: ");
    var nome = Console.ReadLine() ?? string.Empty;
    Console.Write("Código: ");
    var codigo = Console.ReadLine() ?? string.Empty;
    Console.Write("Quantidade: ");
    var quantidadeValida = int.TryParse(Console.ReadLine(), out var quantidade);
    Console.Write("Valor unitário: ");
    var valorValido = decimal.TryParse(Console.ReadLine(), out var valorUnitario);
    Console.Write("Data de validade (YYYY-MM-DD): ");
    var dataValidade = DateTime.TryParse(Console.ReadLine(), out var validade) ? validade : DateTime.Today;

    if (!quantidadeValida || !valorValido)
    {
        Console.WriteLine("\nQuantidade ou valor inválido.");
        return;
    }

    try
    {
        estoqueService.AdicionarProduto(new ProdutoPerecivel(nome, codigo, quantidade, valorUnitario, dataValidade));
        Console.WriteLine($"\n✔ Produto '{nome}' cadastrado com sucesso!");
    }
    catch (Exception e)
    {
        Console.WriteLine($"\nERRO: {e.Message}");
    }
}

void CadastrarProdutoEletronico()
{
    Console.Clear();
    Console.WriteLine("╔════════════════════════════════════════╗");
    Console.WriteLine("║      CADASTRAR PRODUTO ELETRÔNICO      ║");
    Console.WriteLine("╚════════════════════════════════════════╝");
    Console.Write("Nome: ");
    var nome = Console.ReadLine() ?? string.Empty;
    Console.Write("Código: ");
    var codigo = Console.ReadLine() ?? string.Empty;
    Console.Write("Quantidade: ");
    var quantidadeValida = int.TryParse(Console.ReadLine(), out var quantidade);
    Console.Write("Valor unitário: ");
    var valorValido = decimal.TryParse(Console.ReadLine(), out var valorUnitario);
    Console.Write("Garantia em meses: ");
    var garantiaValida = int.TryParse(Console.ReadLine(), out var garantia);

    if (!quantidadeValida || !valorValido || !garantiaValida)
    {
        Console.WriteLine("\nQuantidade, valor ou garantia inválida.");
        return;
    }

    try
    {
        estoqueService.AdicionarProduto(new ProdutoEletronico(nome, codigo, quantidade, valorUnitario, garantia));
        Console.WriteLine($"\n✔ Produto '{nome}' cadastrado com sucesso!");
    }
    catch (Exception e)
    {
        Console.WriteLine($"\nERRO: {e.Message}");
    }
}

void CadastrarProdutoLimpeza()
{
    Console.Clear();
    Console.WriteLine("╔════════════════════════════════════════╗");
    Console.WriteLine("║      CADASTRAR PRODUTO DE LIMPEZA      ║");
    Console.WriteLine("╚════════════════════════════════════════╝");
    Console.Write("Nome: ");
    var nome = Console.ReadLine() ?? string.Empty;
    Console.Write("Código: ");
    var codigo = Console.ReadLine() ?? string.Empty;
    Console.Write("Quantidade: ");
    var quantidadeValida = int.TryParse(Console.ReadLine(), out var quantidade);
    Console.Write("Valor unitário: ");
    var valorValido = decimal.TryParse(Console.ReadLine(), out var valorUnitario);
    Console.Write("Composição química: ");
    var composicao = Console.ReadLine() ?? string.Empty;

    if (!quantidadeValida || !valorValido)
    {
        Console.WriteLine("\nQuantidade ou valor inválido.");
        return;
    }

    try
    {
        estoqueService.AdicionarProduto(new ProdutoLimpeza(nome, codigo, quantidade, valorUnitario, composicao));
        Console.WriteLine($"\n✔ Produto '{nome}' cadastrado com sucesso!");
    }
    catch (Exception e)
    {
        Console.WriteLine($"\nERRO: {e.Message}");
    }
}

void CadastrarProdutoControlado()
{
    Console.Clear();
    Console.WriteLine("╔════════════════════════════════════════╗");
    Console.WriteLine("║      CADASTRAR PRODUTO CONTROLADO      ║");
    Console.WriteLine("╚════════════════════════════════════════╝");
    Console.Write("Nome: ");
    var nome = Console.ReadLine() ?? string.Empty;
    Console.Write("Código: ");
    var codigo = Console.ReadLine() ?? string.Empty;
    Console.Write("Quantidade: ");
    var quantidadeValida = int.TryParse(Console.ReadLine(), out var quantidade);
    Console.Write("Valor unitário: ");
    var valorValido = decimal.TryParse(Console.ReadLine(), out var valorUnitario);
    Console.Write("Requer autorização (s/n): ");
    var requerAutorizacao = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant() == "s";

    if (!quantidadeValida || !valorValido)
    {
        Console.WriteLine("\nQuantidade ou valor inválido.");
        return;
    }

    try
    {
        estoqueService.AdicionarProduto(new ProdutoControlado(nome, codigo, quantidade, valorUnitario, requerAutorizacao));
        Console.WriteLine($"\n✔ Produto '{nome}' cadastrado com sucesso!");
    }
    catch (Exception e)
    {
        Console.WriteLine($"\nERRO: {e.Message}");
    }
}

void ListarProdutos()
{
    Console.Clear();
    Console.WriteLine("╔════════════════════════════════════════╗");
    Console.WriteLine("║          PRODUTOS CADASTRADOS          ║");
    Console.WriteLine("╚════════════════════════════════════════╝");

    var produtos = estoqueService.ObterProdutos().ToList();
    if (!produtos.Any())
    {
        Console.WriteLine("Nenhum produto cadastrado.");
        return;
    }

    foreach (var produto in produtos)
    {
        Console.WriteLine();
        Console.WriteLine($"Nome: {produto.Nome} ({produto.Codigo})");
        Console.WriteLine($"Tipo: {produto.GetType().Name}");
        Console.WriteLine($"Risco: {produto.CalcularRiscoEstoque()}");
        Console.WriteLine($"Armazenamento: {produto.ObterInstrucaoArmazenamento()}");
        Console.WriteLine($"Valor bruto: {produto.CalcularValorTotalBruto():C2}");
        Console.WriteLine($"Valor ajustado: {produto.CalcularValorTotalAjustado():C2}");
        Console.WriteLine("----------------------------------------");
    }
}

void ExibirRelatorio()
{
    Console.Clear();
    Console.WriteLine("╔════════════════════════════════════════╗");
    Console.WriteLine("║          RELATÓRIO DE ESTOQUE           ║");
    Console.WriteLine("╚════════════════════════════════════════╝");

    var relatorio = RelatorioService.GerarRelatorio(estoqueService.ObterProdutos());
    Console.WriteLine(relatorio);
}
