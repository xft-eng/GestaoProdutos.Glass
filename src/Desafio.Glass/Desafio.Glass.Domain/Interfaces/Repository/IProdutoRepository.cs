using Desafio.Glass.Domain.DTO.DesafioGlass;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Glass.Domain.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        Task<Produto> ObterProdutoPorIdAsync(int id);
        Task<IEnumerable<Produto>> ObterProdutosCompeseAsync(Produto vmProduto, int pageSize, int skip);
        Task<Produto> IncluirAsync(Produto vmPoste);
        Task<Produto> EditarAsync(Produto vmPoste);

    }
}
