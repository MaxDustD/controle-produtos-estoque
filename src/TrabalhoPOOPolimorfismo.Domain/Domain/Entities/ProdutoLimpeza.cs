namespace TrabalhoPOOPolimorfismo.Domain.Entities;

public sealed class ProdutoLimpeza : Produto
{
    public ProdutoLimpeza(string nome, string codigo, int quantidade, decimal valorUnitario, string composicaoQuimica)
        : base(nome, codigo, quantidade, valorUnitario)
    {
        if (string.IsNullOrWhiteSpace(composicaoQuimica))
        {
            throw new ArgumentException("Composição química não pode ser vazia.", nameof(composicaoQuimica));
        }

        ComposicaoQuimica = composicaoQuimica;
    }

    public string ComposicaoQuimica { get; }

    public override string CalcularRiscoEstoque()
    {
        string composicao = ComposicaoQuimica.ToLowerInvariant();
        bool perigoso = composicao.Contains("ácido") || composicao.Contains("inflamável") || composicao.Contains("corrosivo");

        return perigoso ? "Alto - produto químico perigoso" : "Médio";
    }

    public override string ObterInstrucaoArmazenamento()
    {
        return "Manter em local ventilado, afastado de alimentos e fora do alcance de crianças.";
    }

    public override decimal CalcularValorTotalAjustado()
    {
        decimal fator = ComposicaoQuimica.ToLowerInvariant().Contains("inflamável") || ComposicaoQuimica.ToLowerInvariant().Contains("ácido")
            ? 1.15m
            : 1.05m;

        return CalcularValorTotalBruto() * fator;
    }

    public override string ToString()
    {
        return $"{base.ToString()} - Composição: {ComposicaoQuimica}";
    }
}
