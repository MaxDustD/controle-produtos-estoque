namespace TrabalhoPOOPolimorfismo.Domain.Entities;

/// <summary>
/// Abstração comum para todos os produtos em estoque.
/// Contém propriedades essenciais, validações no construtor e comportamento reutilizável.
/// </summary>
public abstract class Produto
{
    protected Produto(string nome, string codigo, int quantidade, decimal valorUnitario)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("Nome do produto não pode ser vazio.", nameof(nome));
        }

        if (string.IsNullOrWhiteSpace(codigo))
        {
            throw new ArgumentException("Código do produto não pode ser vazio.", nameof(codigo));
        }

        if (quantidade <= 0)
        {
            throw new ArgumentException("Quantidade deve ser maior que zero.", nameof(quantidade));
        }

        if (valorUnitario < 0)
        {
            throw new ArgumentException("Valor unitário deve ser maior ou igual a zero.", nameof(valorUnitario));
        }

        Nome = nome;
        Codigo = codigo;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
    }

    public string Nome { get; }
    public string Codigo { get; }
    public int Quantidade { get; }
    public decimal ValorUnitario { get; }

    public decimal CalcularValorTotalBruto()
    {
        return Quantidade * ValorUnitario;
    }

    public abstract string CalcularRiscoEstoque();

    public abstract string ObterInstrucaoArmazenamento();

    public abstract decimal CalcularValorTotalAjustado();

    public override string ToString()
    {
        return $"{Nome} ({Codigo}) - Quantidade: {Quantidade} - Unitário: {ValorUnitario:C2}";
    }
}
