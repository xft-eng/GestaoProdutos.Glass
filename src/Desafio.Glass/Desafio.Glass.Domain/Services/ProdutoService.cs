using Desafio.Glass.Domain.DTO.DesafioGlass;
using Desafio.Glass.Domain.Interfaces.Repository;
using Desafio.Glass.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Glass.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository) =>
            _repository = repository;

        public async Task<Produto> ListarProdutoPorIdAsync(int id)
        {
            return await _repository.ObterProdutoPorIdAsync(id).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Produto>> ListarProdutosComposeAsync(Produto vmProduto, int pageSize, int skip)
        {
            return await _repository.ObterProdutosCompeseAsync(vmProduto, pageSize, skip).ConfigureAwait(true);
        }

        public async Task<Produto> IncluirAsync(Produto vmProduto)
        {
            return await _repository.IncluirAsync(vmProduto).ConfigureAwait(true);
        }

        public async Task<Produto> EditarAsync(Produto vmProduto)
        {
            return await _repository.EditarAsync(vmProduto).ConfigureAwait(true);
        }
    }
}
