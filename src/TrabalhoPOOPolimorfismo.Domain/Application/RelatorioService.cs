using System.Text;
using TrabalhoPOOPolimorfismo.Domain.Entities;

namespace TrabalhoPOOPolimorfismo.Domain.Application;

public static class RelatorioService
{
    public static string GerarRelatorio(IEnumerable<Produto> produtos)
    {
        var builder = new StringBuilder();
        builder.AppendLine("=== Relatório de Estoque ===");
        builder.AppendLine($"Data da geração: {DateTime.Now:dd/MM/yyyy HH:mm}");
        builder.AppendLine();

        foreach (var produto in produtos)
        {
            builder.AppendLine(produto.ToString());
            builder.AppendLine($"Risco de estoque: {produto.CalcularRiscoEstoque()}");
            builder.AppendLine($"Instrução de armazenamento: {produto.ObterInstrucaoArmazenamento()}");
            builder.AppendLine($"Valor bruto: {produto.CalcularValorTotalBruto():C2}");
            builder.AppendLine($"Valor ajustado: {produto.CalcularValorTotalAjustado():C2}");
            builder.AppendLine(new string('-', 60));
        }

        return builder.ToString();
    }
}
