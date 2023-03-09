using FluentValidation;
using System.Text.RegularExpressions;
using TemplateAPI.Domain.Entities;

namespace TemplateAPI.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(x => x.Logradouro)
                .NotEmpty()
                .WithMessage("O endere�o precisa ser preenchido")
                .MinimumLength(4)
                .WithMessage("O endere�o dever� ter no m�nimo 4 caract�res")
                .MaximumLength(300)
                .WithMessage("O endere�o dever� ter no m�ximo 300 caract�res");

            RuleFor(x => x.Bairro)
                .NotEmpty()
                .WithMessage("Informe um bairro, � obrigat�rio")
                .MinimumLength(4)
                .WithMessage("O bairro dever� ter no m�nimo 4 caract�res")
                .MaximumLength(40)
                .WithMessage("O bairro dever� ter no m�ximo 40 caract�res");

            RuleFor(x => x.Cidade)
                .NotEmpty()
                .WithMessage("A cidade dever� ser informada")
                .MinimumLength(5)
                .WithMessage("A cidade dever� ter no m�nimo 5 caract�res")
                .MaximumLength(20)
                .WithMessage("A cidade dever� ter no m�ximo 20 caract�res");

            RuleFor(x => x.Estado)
                .NotEmpty()
                .WithMessage("O estado dever� ser informado")
                .MinimumLength(2)
                .WithMessage("O estado dever� ter no m�nimo 5 caract�res")
                .MaximumLength(2)
                .WithMessage("O estado dever� ter no m�ximo 2 caract�res");

            RuleFor(x => x.CEP)
                .NotEmpty()
                .WithMessage("O estado dever� ser informado")
                .MinimumLength(2)
                .Must(ValidaCEP)
                .WithMessage("Insira um CEP v�lido");
        }

        private static bool ValidaCEP(string cep)
        {
            Regex Rgx = new Regex(@"^\d{5}-\d{3}$");

            if (!Rgx.IsMatch(cep))
                return false;
            else
                return true;
        }
    }
}
