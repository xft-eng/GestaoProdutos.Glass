using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Glass.Domain.DTO.DesafioGlass.CustomConsult
{
        public class CustomConsultProduto : ICustomQueryable
        {

        public CustomConsultProduto(string descricaoProduto, bool? situacaoProduto, DateTime? dataFabricacao, DateTime? dataValidade
            , string codFornecedor, string descricaoFornecedor, string cnpj)
        {
            DescricaoProduto = descricaoProduto;
            SituacaoProduto = situacaoProduto;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            CodFornecedor = codFornecedor;
            DescricaoFornecedor = descricaoFornecedor;
            CNPJ = cnpj;

        }
        [QueryOperator(Operator = WhereOperator.Contains)]
        public string DescricaoProduto { get; private set; }
        public bool? SituacaoProduto { get; private set; }
        public DateTime? DataFabricacao { get; private set; }
        public DateTime? DataValidade { get; private set; }
        [QueryOperator(Operator = WhereOperator.Contains)]
        public string CodFornecedor { get; private set; }
        [QueryOperator(Operator = WhereOperator.Contains)]
        public string DescricaoFornecedor { get; private set; }
        public string CNPJ { get; private set; }
        }
    
}
