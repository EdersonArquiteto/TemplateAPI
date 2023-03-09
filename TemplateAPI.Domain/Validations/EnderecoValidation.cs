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
                .WithMessage("O endereço precisa ser preenchido")
                .MinimumLength(4)
                .WithMessage("O endereço deverá ter no mínimo 4 caractéres")
                .MaximumLength(300)
                .WithMessage("O endereço deverá ter no máximo 300 caractéres");

            RuleFor(x => x.Bairro)
                .NotEmpty()
                .WithMessage("Informe um bairro, é obrigatório")
                .MinimumLength(4)
                .WithMessage("O bairro deverá ter no mínimo 4 caractéres")
                .MaximumLength(40)
                .WithMessage("O bairro deverá ter no máximo 40 caractéres");

            RuleFor(x => x.Cidade)
                .NotEmpty()
                .WithMessage("A cidade deverá ser informada")
                .MinimumLength(5)
                .WithMessage("A cidade deverá ter no mínimo 5 caractéres")
                .MaximumLength(20)
                .WithMessage("A cidade deverá ter no máximo 20 caractéres");

            RuleFor(x => x.Estado)
                .NotEmpty()
                .WithMessage("O estado deverá ser informado")
                .MinimumLength(2)
                .WithMessage("O estado deverá ter no mínimo 5 caractéres")
                .MaximumLength(2)
                .WithMessage("O estado deverá ter no máximo 2 caractéres");

            RuleFor(x => x.CEP)
                .NotEmpty()
                .WithMessage("O estado deverá ser informado")
                .MinimumLength(2)
                .Must(ValidaCEP)
                .WithMessage("Insira um CEP válido");
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
