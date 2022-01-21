using System;

namespace Desafio.Glass.Domain.DTO.DesafioGlass
{
    public class Produto
    {
        public int Id { get; private set; }
        public string DescricaoProduto { get; private set; }
        public bool? SituacaoProduto { get; private set; }
        public DateTime? DataFabricacao { get; private set; }
        public DateTime? DataValidade { get; private set; }
        public string CodFornecedor { get; private set; }
        public string DescricaoFornecedor { get; private set; }
        public string CNPJ { get; private set; }
    }

}
