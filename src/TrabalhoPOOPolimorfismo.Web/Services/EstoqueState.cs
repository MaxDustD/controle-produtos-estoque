using TrabalhoPOOPolimorfismo.Domain.Entities;
using TrabalhoPOOPolimorfismo.Domain.Infra;
using TrabalhoPOOPolimorfismo.Domain.Services;

namespace TrabalhoPOOPolimorfismo.Web.Services;

public sealed class EstoqueState
{
    private readonly EstoqueService _estoqueService;

    public EstoqueState()
    {
        _estoqueService = new EstoqueService(new RepositorioProdutoInMemory());
        SeedProdutosIniciais();
    }

    public IReadOnlyCollection<Produto> Produtos => _estoqueService.ObterProdutos();

    public string Mensagem { get; private set; } = "O estoque está pronto. Use o formulário para adicionar novos produtos.";

    public string MensagemClasse { get; private set; } = "success";

    public int TotalProdutos => Produtos.Count;

    public decimal TotalBruto => Produtos.Sum(p => p.CalcularValorTotalBruto());

    public decimal TotalAjustado => Produtos.Sum(p => p.CalcularValorTotalAjustado());

    public void AdicionarProduto(ProdutoTipo tipo, string nome, string codigo, int quantidade, decimal valorUnitario, DateTime dataValidade, int garantiaMeses, string composicaoQuimica, bool requerAutorizacao)
    {
        try
        {
            Produto produto = tipo switch
            {
                ProdutoTipo.Perecivel => new ProdutoPerecivel(nome, codigo, quantidade, valorUnitario, dataValidade),
                ProdutoTipo.Eletronico => new ProdutoEletronico(nome, codigo, quantidade, valorUnitario, garantiaMeses),
                ProdutoTipo.Limpeza => new ProdutoLimpeza(nome, codigo, quantidade, valorUnitario, composicaoQuimica),
                ProdutoTipo.Controlado => new ProdutoControlado(nome, codigo, quantidade, valorUnitario, requerAutorizacao),
                _ => throw new InvalidOperationException("Tipo de produto inválido."),
            };

            _estoqueService.AdicionarProduto(produto);
            Mensagem = $"Produto '{nome}' adicionado com sucesso!";
            MensagemClasse = "success";
        }
        catch (Exception error)
        {
            Mensagem = error.Message;
            MensagemClasse = "danger";
        }
    }

    public string ObterClasseRisco(Produto produto)
    {
        var risco = produto.CalcularRiscoEstoque();
        return risco.Contains("Alto") ? "risk-high"
            : risco.Contains("Médio") ? "risk-medium"
            : "risk-low";
    }

    public int ContarPorTipo(ProdutoTipo tipo)
    {
        return Produtos.Count(p => tipo switch
        {
            ProdutoTipo.Perecivel => p is ProdutoPerecivel,
            ProdutoTipo.Eletronico => p is ProdutoEletronico,
            ProdutoTipo.Limpeza => p is ProdutoLimpeza,
            ProdutoTipo.Controlado => p is ProdutoControlado,
            _ => false,
        });
    }

    private void SeedProdutosIniciais()
    {
        if (Produtos.Any())
        {
            return;
        }

        _estoqueService.AdicionarProduto(new ProdutoPerecivel("Leite Integral", "P001", 20, 5.99m, DateTime.Today.AddDays(6)));
        _estoqueService.AdicionarProduto(new ProdutoEletronico("Fone Bluetooth", "E001", 10, 199.90m, 24));
        _estoqueService.AdicionarProduto(new ProdutoLimpeza("Detergente", "L001", 18, 8.49m, "Fosfato e aromas suaves"));
        _estoqueService.AdicionarProduto(new ProdutoControlado("Desinfetante Hospitalar", "C001", 5, 32.50m, true));
    }
}
