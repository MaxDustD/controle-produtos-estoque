namespace TrabalhoPOOPolimorfismo.Domain.Entities;

public sealed class ProdutoEletronico : Produto
{
    public ProdutoEletronico(string nome, string codigo, int quantidade, decimal valorUnitario, int garantiaMeses)
        : base(nome, codigo, quantidade, valorUnitario)
    {
        if (garantiaMeses < 0)
        {
            throw new ArgumentException("Garantia em meses não pode ser negativa.", nameof(garantiaMeses));
        }

        GarantiaMeses = garantiaMeses;
    }

    public int GarantiaMeses { get; }

    public override string CalcularRiscoEstoque()
    {
        return GarantiaMeses switch
        {
            <= 3 => "Alto - risco de obsolescência",
            <= 12 => "Médio",
            _ => "Baixo",
        };
    }

    public override string ObterInstrucaoArmazenamento()
    {
        return "Guardar em local seco, protegido de umidade e sem impacto físico.";
    }

    public override decimal CalcularValorTotalAjustado()
    {
        decimal depreciacao = Math.Clamp(1.0m - GarantiaMeses * 0.01m, 0.70m, 0.95m);
        return CalcularValorTotalBruto() * depreciacao;
    }

    public override string ToString()
    {
        return $"{base.ToString()} - Garantia: {GarantiaMeses} mês(es)";
    }
}
