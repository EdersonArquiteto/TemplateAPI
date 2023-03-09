using FluentValidation.Results;

namespace TemplateAPI.Domain.Core
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }

        ValidationResult Validate { get; }
    }
}
