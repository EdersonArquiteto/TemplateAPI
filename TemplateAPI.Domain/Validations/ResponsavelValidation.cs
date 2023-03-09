using FluentValidation;
using TemplateAPI.Domain.Entities;
using TemplateAPI.Validations.Documentos;

namespace TemplateAPI.Validations
{
    public class ResponsavelValidation : AbstractValidator<Responsavel>
    {
        public ResponsavelValidation()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(5)
                .WithMessage("Você excedeu o mínimo de caractéres (5)")
                .MaximumLength(250)
                .WithMessage("Você excedeu o máximo de caractéres (250)")
                .NotEmpty()
                .WithMessage("O nome deverá ser preenchido");

            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .WithMessage("Insira uma data de nascimento")
                .LessThan(DateTime.Now)
                .WithMessage("A data de nascimento deverá ser menor que a data de hoje")
                .Must(isMaiorDeIdade)
                .WithMessage("O responsável deverá ser maior de idade");

            RuleFor(x => x.CPF)
                .NotEmpty()
                .WithMessage("O CPF do responsável é obrigatório")
                .SetValidator(new CPFValidation())
                .WithMessage("Informe um CPF válido.")
                .When(x => x.ResponsavelNF);

            RuleFor(x => x.RG)
                .NotEmpty()
                .WithMessage("O RG do responsável é obrigatório");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O EMAIL do responsável é obrigatório")
                .SetValidator(new EmailValidation())
                .WithMessage("Informe um EMAIL válido.")
                .When(x => x.ResponsavelPrincipal);

            RuleFor(x => x.Telefone)
                .SetValidator(new TelefoneValidation())
                .WithMessage("O Telefone do responsável é obrigatório");

            RuleFor(x => x.Celular)
                .SetValidator(new TelefoneValidation())
                .WithMessage("O Celular do responsável é obrigatório");

        }

        private static bool isMaiorDeIdade(DateTime dNascimento)
        {
            return dNascimento <= DateTime.Now.AddYears(-18);
        }
    }
}
