namespace TemplateAPI.Domain.VO
{
    public class Email
    {
        public string Value { get; set; }
        public Email()
        {

        }

        public Email(string email)
        {
            this.Value = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
