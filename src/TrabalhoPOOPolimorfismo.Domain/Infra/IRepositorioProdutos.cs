using TrabalhoPOOPolimorfismo.Domain.Entities;

namespace TrabalhoPOOPolimorfismo.Domain.Infra;

public interface IRepositorioProdutos
{
    void Adicionar(Produto produto);

    IReadOnlyCollection<Produto> ObterTodos();
}
