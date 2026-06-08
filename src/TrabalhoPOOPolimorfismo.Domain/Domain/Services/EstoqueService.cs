using TrabalhoPOOPolimorfismo.Domain.Entities;
using TrabalhoPOOPolimorfismo.Domain.Infra;

namespace TrabalhoPOOPolimorfismo.Domain.Services;

public sealed class EstoqueService
{
    private readonly IRepositorioProdutos _repositorio;

    public EstoqueService(IRepositorioProdutos repositorio)
    {
        _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
    }

    public void AdicionarProduto(Produto produto)
    {
        _repositorio.Adicionar(produto);
    }

    public IReadOnlyCollection<Produto> ObterProdutos()
    {
        return _repositorio.ObterTodos();
    }
}
