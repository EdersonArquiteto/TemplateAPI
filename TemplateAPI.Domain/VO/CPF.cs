namespace TemplateAPI.Domain.VO
{
    public class CPF
    {
        public CPF()
        {

        }

        public CPF(string value)
        {
            this.Value = value?.Replace(".", "").Replace("-", "") ?? throw new ArgumentNullException(nameof(CPF));
        }

        public string FormatValue => Format(this.Value);

        private string Format(string value) => Convert.ToInt64(value).ToString(@"000\.000\.000\-00");

        public string Value { get; set; }
    }
}
