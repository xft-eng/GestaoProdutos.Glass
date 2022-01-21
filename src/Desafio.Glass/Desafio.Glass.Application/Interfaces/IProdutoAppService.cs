using Desafio.Glass.Application.Model;
using Desafio.Glass.Application.Model.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Glass.Application.Interfaces
{
    public interface IProdutoAppService
    {
        Task<ProdutoModel> ListarPorIdAsync(int id);
        Task<IEnumerable<ProdutoModel>> ListarProdutosComposeAsync(ConsultaProdutoModel vmProduto, int pageSize, int skip);
        Task<ProdutoModel> IncluirAsync(ProdutoModel vmProduto);
        Task<ProdutoModel> EditarAsync(ProdutoModel vmProduto);

    }
}
