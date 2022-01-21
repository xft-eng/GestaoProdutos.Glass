using Desafio.Glass.Application.Model;
using FluentValidation;

namespace Desafio.Glass.Application.Validators
{
    public class ProdutoModelValidator : AbstractValidator<ProdutoModel>
    {

        public ProdutoModelValidator()
        {

            RuleFor(qc => qc.DescricaoProduto)
                          .Cascade(CascadeMode.Stop)
                          .NotEmpty()
                          .WithMessage("Favor informar a descrição do produto");


            When(qc => qc.DataFabricacao >= qc.DataValidade, () =>
            {
                RuleFor(qc => qc.DataFabricacao)
                     .Cascade(CascadeMode.Stop)
                     .Empty()
                     .WithMessage("A Data de Fabricação que não pode ser maior ou igual a data de validade.");
            });

        }
    }
}
