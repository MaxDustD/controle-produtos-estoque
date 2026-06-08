using System.Globalization;

namespace TrabalhoPOOPolimorfismo.Domain.Entities;

public sealed class ProdutoPerecivel : Produto
{
    public ProdutoPerecivel(string nome, string codigo, int quantidade, decimal valorUnitario, DateTime dataValidade)
        : base(nome, codigo, quantidade, valorUnitario)
    {
        DataValidade = dataValidade.Date;
    }

    public DateTime DataValidade { get; }

    private int ObterDiasParaValidade()
    {
        return (DataValidade - DateTime.Today).Days;
    }

    public override string CalcularRiscoEstoque()
    {
        int dias = ObterDiasParaValidade();

        return dias switch
        {
            <= 0 => "Alto - produto vencido",
            <= 2 => "Alto",
            <= 7 => "Médio",
            _ => "Baixo",
        };
    }

    public override string ObterInstrucaoArmazenamento()
    {
        return "Manter refrigerado ou em ambiente controlado para evitar perda rápida.";
    }

    public override decimal CalcularValorTotalAjustado()
    {
        int dias = ObterDiasParaValidade();

        decimal fator = dias switch
        {
            <= 0 => 0.0m,
            <= 2 => 0.5m,
            <= 5 => 0.75m,
            <= 10 => 0.9m,
            _ => 1.0m,
        };

        return CalcularValorTotalBruto() * fator;
    }

    public override string ToString()
    {
        return $"{base.ToString()} - Validade: {DataValidade:dd/MM/yyyy}";
    }
}
