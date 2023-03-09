
using FluentValidation.Results;
using TemplateAPI.Domain.Core;
using TemplateAPI.Domain.VO;
using TemplateAPI.Validations;

namespace TemplateAPI.Domain.Entities
{
    public class Paciente : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataPrimeiraAvaliacao { get; set; }
        public string? Idade => CalculaIdade(DataNascimento);
        public bool ResponsavelNF { get; set; }
        public string? RG { get; set; }
        public CPF CPF { get; set; }

        public virtual List<Responsavel>? Responsaveis { get; set; }
        public Endereco? Endereco { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }

        public ValidationResult Validate => new PacienteValidation().Validate(this);

        public static string CalculaIdade(DateTime dNasccimento)
        {
            int idade = DateTime.Now.Year - dNasccimento.Year;
            if (DateTime.Now.DayOfYear < dNasccimento.DayOfYear)
            {
                idade--;
            }

            if (idade == 0)
            {
                int anos = new DateTime(DateTime.Now.Subtract(dNasccimento).Ticks).Year - 1;
                DateTime AnosTranscorridos = dNasccimento.AddYears(anos);
                int meses = 0;

                for (int i = 0; i <= 12; i++)
                {
                    if (AnosTranscorridos.AddMonths(i) == DateTime.Now)
                    {
                        meses = i;
                        break;
                    }
                    else if (AnosTranscorridos.AddMonths(i) >= DateTime.Now)
                    {
                        meses = i--;
                        break;
                    }
                }

                return $"{meses} meses.";
            }

            return $"{idade.ToString()} anos";
        }
    }
}
