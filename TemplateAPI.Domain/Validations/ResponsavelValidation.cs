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
                .WithMessage("Voc� excedeu o m�nimo de caract�res (5)")
                .MaximumLength(250)
                .WithMessage("Voc� excedeu o m�ximo de caract�res (250)")
                .NotEmpty()
                .WithMessage("O nome dever� ser preenchido");

            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .WithMessage("Insira uma data de nascimento")
                .LessThan(DateTime.Now)
                .WithMessage("A data de nascimento dever� ser menor que a data de hoje")
                .Must(isMaiorDeIdade)
                .WithMessage("O respons�vel dever� ser maior de idade");

            RuleFor(x => x.CPF)
                .NotEmpty()
                .WithMessage("O CPF do respons�vel � obrigat�rio")
                .SetValidator(new CPFValidation())
                .WithMessage("Informe um CPF v�lido.")
                .When(x => x.ResponsavelNF);

            RuleFor(x => x.RG)
                .NotEmpty()
                .WithMessage("O RG do respons�vel � obrigat�rio");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O EMAIL do respons�vel � obrigat�rio")
                .SetValidator(new EmailValidation())
                .WithMessage("Informe um EMAIL v�lido.")
                .When(x => x.ResponsavelPrincipal);

            RuleFor(x => x.Telefone)
                .SetValidator(new TelefoneValidation())
                .WithMessage("O Telefone do respons�vel � obrigat�rio");

            RuleFor(x => x.Celular)
                .SetValidator(new TelefoneValidation())
                .WithMessage("O Celular do respons�vel � obrigat�rio");

        }

        private static bool isMaiorDeIdade(DateTime dNascimento)
        {
            return dNascimento <= DateTime.Now.AddYears(-18);
        }
    }
}
