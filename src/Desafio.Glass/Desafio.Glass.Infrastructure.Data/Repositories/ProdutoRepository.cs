using Desafio.Glass.Domain.DTO.DesafioGlass;
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

        public async Task<Produto> IncluirAsync(Produto vmPoste)
        {

            _context.Produto.Add(vmPoste);
            await _context.SaveChangesAsync();
            return vmPoste;
        }

        public async Task<Produto> EditarAsync(Produto vmPoste)
        {

            _context.Entry(vmPoste).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return vmPoste;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }


        public async Task<IEnumerable<Produto>> ObterProdutosCompeseAsync(Produto vmProduto, int pageSize, int skip)
        {
            IQueryable<Produto> query = _context.Produto;

            if (!string.IsNullOrEmpty(vmProduto.DescricaoProduto))
            {
                query = query.Where(where => where.DescricaoProduto.Contains(vmProduto.DescricaoProduto))
                             .Take(pageSize)
                             .Skip(skip);
            }

            if (vmProduto.SituacaoProduto != null)
            {
                query = query.Where(where => where.SituacaoProduto == vmProduto.SituacaoProduto)
                             .Take(pageSize)
                             .Skip(skip); ;
            }

            if (vmProduto.DataFabricacao != null)
            {
                query = query.Where(where => where.DataFabricacao == vmProduto.DataFabricacao)
                             .Take(pageSize)
                             .Skip(skip); ;
            }

            if (vmProduto.DataValidade != null)
            {
                query = query.Where(where => where.DataValidade == vmProduto.DataValidade)
                             .Take(pageSize)
                             .Skip(skip); ;
            }

            if (!string.IsNullOrEmpty(vmProduto.CodFornecedor))
            {
                query = query.Where(where => where.CodFornecedor == vmProduto.CodFornecedor)
                             .Take(pageSize)
                             .Skip(skip); ;
            }

            if (!string.IsNullOrEmpty(vmProduto.DescricaoFornecedor))
            {
                query = query.Where(where => where.DescricaoFornecedor.Contains(vmProduto.DescricaoFornecedor))
                             .Take(pageSize)
                             .Skip(skip); ;
            }
            if (!string.IsNullOrEmpty(vmProduto.CNPJ))
            {
                query = query.Where(where => where.CNPJ == vmProduto.CNPJ)
                             .Take(pageSize)
                             .Skip(skip); ;
            }

            return await query.ToListAsync();
        }

    }
}
