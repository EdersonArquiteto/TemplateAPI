using FluentValidation;
using TemplateAPI.Domain.Entities;
using TemplateAPI.Validations.Documentos;

namespace TemplateAPI.Validations
{
    public class PacienteValidation : AbstractValidator<Paciente>
    {
        public PacienteValidation()
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
                .WithMessage("A data de nascimento deverá ser menor que a data de hoje");

            RuleFor(x => x.DataPrimeiraAvaliacao)
                .NotEmpty()
                .WithMessage("A data da primeira avaliação precisa estar preenchida");

            RuleFor(x => x.CPF)
                .NotEmpty()
                .SetValidator(new CPFValidation())
                .WithMessage("O CPF do paciente é obrigatório para emissão da NF")
                .When(x => x.ResponsavelNF);
        }
    }
}
