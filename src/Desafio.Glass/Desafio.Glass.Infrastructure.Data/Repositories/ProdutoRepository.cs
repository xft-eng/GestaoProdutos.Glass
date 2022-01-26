using AspNetCore.IQueryable.Extensions.Filter;
using Desafio.Glass.Domain.DTO.DesafioGlass;
using Desafio.Glass.Domain.DTO.DesafioGlass.CustomConsult;
using Desafio.Glass.Domain.Interfaces.Repository;
using Desafio.Glass.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Glass.Infrastructure.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly GestaoProdutoDbContext _context;

        public ProdutoRepository(GestaoProdutoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Produto> ObterProdutoPorIdAsync(int id)
        {
            return await _context.Produto
                 .Where(p => p.Id == id)
                 .FirstOrDefaultAsync();
        }

        public async Task<Produto> IncluirAsync(Produto vmProduto)
        {

            _context.Produto.Add(vmProduto);
            await _context.SaveChangesAsync();
            return vmProduto;
        }

        public async Task<Produto> EditarAsync(Produto vmProduto)
        {

            _context.Entry(vmProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return vmProduto;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }


        public async Task<IEnumerable<Produto>> ObterProdutosCompeseAsync(Produto vmProduto, int pageSize, int skip)
        {
            var descricaoProduto = vmProduto.DescricaoProduto;
            var situacaoProduto = vmProduto.SituacaoProduto;
            var dataFabricacao = vmProduto.DataFabricacao;
            var dataValidade = vmProduto.DataValidade;
            var codFornecedor = vmProduto.CodFornecedor;
            var descricaoFornecedor = vmProduto.DescricaoFornecedor;
            var cnpj = vmProduto.CNPJ;

            var filter = new CustomConsultProduto(descricaoProduto, situacaoProduto, dataFabricacao, dataValidade, codFornecedor, descricaoFornecedor, cnpj);

            var query = await _context.Produto.AsQueryable().Filter(filter).Take(pageSize).Skip(skip).ToListAsync();

            return  query;
        }

    }
}
