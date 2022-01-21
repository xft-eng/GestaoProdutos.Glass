using Desafio.Glass.Application.Validators;
using System;

namespace Desafio.Glass.Application.Model
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string DescricaoProduto { get; set; }
        public bool? SituacaoProduto { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public string CodFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }

        [CustomValidateCNPJ(ErrorMessage = "O CNPJ informado é inválido")]
        public string CNPJ { get; set; }
    }
}
