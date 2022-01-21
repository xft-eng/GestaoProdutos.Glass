using AutoMapper;
using Desafio.Glass.Application.Interfaces;
using Desafio.Glass.Application.Model;
using Desafio.Glass.Application.Model.Input;
using Desafio.Glass.Domain.DTO.DesafioGlass;
using Desafio.Glass.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Glass.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {

        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;


        public ProdutoAppService(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        public async Task<ProdutoModel> ListarPorIdAsync(int id)
        {

            var produto = await _produtoService.ListarProdutoPorIdAsync(id);

            return _mapper.Map<ProdutoModel>(produto);
        }

        public async Task<IEnumerable<ProdutoModel>> ListarProdutosComposeAsync(ConsultaProdutoModel vmProduto, int pageSize, int skip)
        {
            if (vmProduto.CNPJ != null)
            {
                vmProduto.CNPJ = RemoveNonNumerics(vmProduto.CNPJ);
            }

            var vmModel = _mapper.Map<Produto>(vmProduto);

            if (pageSize <= 0)
            {
                pageSize = 20;
            }

            var produto = await _produtoService.ListarProdutosComposeAsync(vmModel, pageSize, skip);

            return _mapper.Map<IEnumerable<ProdutoModel>>(produto);
        }



        public async Task<ProdutoModel> IncluirAsync(ProdutoModel vmProduto)
        {
            vmProduto.CNPJ = RemoveNonNumerics(vmProduto.CNPJ);
            vmProduto.SituacaoProduto = true;

            var vmModel = _mapper.Map<Produto>(vmProduto);

            var produto = await _produtoService.IncluirAsync(vmModel);

            return _mapper.Map<ProdutoModel>(produto);
        }


        public async Task<ProdutoModel> EditarAsync(ProdutoModel vmProduto)
        {
            vmProduto.CNPJ = RemoveNonNumerics(vmProduto.CNPJ);


            var vmModel = _mapper.Map<Produto>(vmProduto);

            var produto = await _produtoService.EditarAsync(vmModel);

            return _mapper.Map<ProdutoModel>(produto);
        }

        #region Methods privates
        private static string RemoveNonNumerics(string text)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");

            string valueOut = reg.Replace(text, string.Empty);

            return valueOut;
        }

        #endregion
    }
}
