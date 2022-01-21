using Desafio.Glass.Domain.DTO.DesafioGlass;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Glass.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<Produto> ListarProdutoPorIdAsync(int id);
        Task<IEnumerable<Produto>> ListarProdutosComposeAsync(Produto vmProduto, int pageSize, int skip);
        Task<Produto> IncluirAsync(Produto vmProduto);
        Task<Produto> EditarAsync(Produto vmProduto);
    }
}
