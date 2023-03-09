namespace TemplateAPI.Domain.VO
{
    public class Telefone
    {
        public string Value { get; set; }

        public Telefone()
        {

        }

        public Telefone(string telefone)
        {
            this.Value = telefone ?? throw new ArgumentNullException(nameof(telefone));
        }
    }
}
