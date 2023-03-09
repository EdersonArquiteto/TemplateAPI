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
                .WithMessage("Voc� excedeu o m�nimo de caract�res (5)")
                .MaximumLength(250)
                .WithMessage("Voc� excedeu o m�ximo de caract�res (250)")
                .NotEmpty()
                .WithMessage("O nome dever� ser preenchido");

            RuleFor(x => x.DataNascimento)
                .NotEmpty()
                .WithMessage("Insira uma data de nascimento")
                .LessThan(DateTime.Now)
                .WithMessage("A data de nascimento dever� ser menor que a data de hoje");

            RuleFor(x => x.DataPrimeiraAvaliacao)
                .NotEmpty()
                .WithMessage("A data da primeira avalia��o precisa estar preenchida");

            RuleFor(x => x.CPF)
                .NotEmpty()
                .SetValidator(new CPFValidation())
                .WithMessage("O CPF do paciente � obrigat�rio para emiss�o da NF")
                .When(x => x.ResponsavelNF);
        }
    }
}
