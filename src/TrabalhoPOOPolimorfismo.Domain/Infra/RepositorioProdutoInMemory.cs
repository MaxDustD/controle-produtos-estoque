using TrabalhoPOOPolimorfismo.Domain.Entities;

namespace TrabalhoPOOPolimorfismo.Domain.Infra;

public sealed class RepositorioProdutoInMemory : IRepositorioProdutos
{
    private readonly List<Produto> _produtos = new();

    public void Adicionar(Produto produto)
    {
        if (produto is null)
        {
            throw new ArgumentNullException(nameof(produto));
        }

        _produtos.Add(produto);
    }

    public IReadOnlyCollection<Produto> ObterTodos()
    {
        return _produtos.AsReadOnly();
    }
}
