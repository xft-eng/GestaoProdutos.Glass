using Desafio.Glass.Application.Model;
using Desafio.Glass.Application.Model.Input;
using FluentValidation;

namespace Desafio.Glass.Application.Validators
{
    public class ConsultaCustomModelValidator : AbstractValidator<ConsultaProdutoModel>
    {

        public ConsultaCustomModelValidator()
        {
            When(qc => qc.DescricaoProduto == null &&
                       qc.SituacaoProduto == null &&
                       qc.DataFabricacao == null &&
                       qc.DataValidade == null &&
                       qc.CodFornecedor == null &&
                       qc.DescricaoFornecedor == null &&
                       qc.CNPJ == null, () =>
            {
                RuleFor(qc => qc.DescricaoProduto)
                     .Cascade(CascadeMode.Stop)
                     .NotEmpty()
                     .WithMessage("Consulta não pode ser realizada por 0 parametros.");
            });

        }
    }
}
