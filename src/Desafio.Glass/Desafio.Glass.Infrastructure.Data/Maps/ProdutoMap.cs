using Desafio.Glass.Domain.DTO.DesafioGlass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Glass.Infrastructure.Data.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired(true);

            builder
                .Property(p => p.DescricaoProduto)
                .HasColumnName("descricao_produto")
                .IsRequired(true);

            builder
                .Property(p => p.SituacaoProduto)
                .HasColumnName("situacao_produto");


            builder
                .Property(p => p.DataFabricacao)
                .HasColumnName("data_fabricacao");


            builder
               .Property(p => p.DataValidade)
               .HasColumnName("data_validade");


            builder
               .Property(p => p.CodFornecedor)
               .HasColumnName("cod_fornecedor");


            builder
               .Property(p => p.DescricaoFornecedor)
               .HasColumnName("desc_fornecedor");


            builder
              .Property(p => p.CNPJ)
              .HasColumnName("cnpj");


            builder
                .ToTable("Produto");
        }
    }
}
