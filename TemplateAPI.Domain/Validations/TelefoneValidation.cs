using FluentValidation;
using System.Text.RegularExpressions;
using TemplateAPI.Domain.VO;

namespace TemplateAPI.Validations
{
    public class TelefoneValidation : AbstractValidator<Telefone>
    {
        public TelefoneValidation()
        {
            RuleFor(x => x.Value).Must(ValidaTelefone).WithMessage("Insira um telefone válido");

        }

        public bool ValidaTelefone(string telefone)
        {
            Regex Rgx = new Regex(@"^\(\d{2}\)\d{4,5}-\d{4}$"); //formato (XX)XXXXX-XXXX ou (XX)XXXX-XXXX 

            if (!Rgx.IsMatch(telefone))
                return false;
            else
                return true;
        }
    }
}
