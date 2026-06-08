namespace TrabalhoPOOPolimorfismo.Domain.Entities;

public sealed class ProdutoControlado : Produto
{
    public ProdutoControlado(string nome, string codigo, int quantidade, decimal valorUnitario, bool requerAutorizacao)
        : base(nome, codigo, quantidade, valorUnitario)
    {
        RequerAutorizacao = requerAutorizacao;
    }

    public bool RequerAutorizacao { get; }

    public override string CalcularRiscoEstoque()
    {
        return RequerAutorizacao ? "Alto - exige controle legal" : "Médio";
    }

    public override string ObterInstrucaoArmazenamento()
    {
        return "Armazenar em local seguro e restrito, com registro de saída e acesso controlado.";
    }

    public override decimal CalcularValorTotalAjustado()
    {
        decimal acrescimo = RequerAutorizacao ? 1.18m : 1.05m;
        return CalcularValorTotalBruto() * acrescimo;
    }

    public override string ToString()
    {
        return $"{base.ToString()} - Requer autorização: {(RequerAutorizacao ? "Sim" : "Não")}";
    }
}
