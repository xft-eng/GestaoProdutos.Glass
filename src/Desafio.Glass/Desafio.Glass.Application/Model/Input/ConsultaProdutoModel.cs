using Desafio.Glass.Application.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Glass.Application.Model.Input
{
    public class ConsultaProdutoModel
    {
        public string DescricaoProduto { get; set; }
        public bool? SituacaoProduto { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataFabricacao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataValidade { get; set; }
        public string CodFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }

        [CustomValidateCNPJ(ErrorMessage = "O CNPJ informado é inválido")]
        public string CNPJ { get; set; }
    }
}
