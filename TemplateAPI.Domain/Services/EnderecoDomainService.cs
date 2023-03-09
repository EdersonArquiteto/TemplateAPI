using TemplateAPI.Domain.Entities;
using TemplateAPI.Domain.Interfaces.Repositories;
using TemplateAPI.Domain.Interfaces.Services;

namespace TemplateAPI.Domain.Services
{
    public class EnderecoDomainService : IBaseDomainService<Endereco, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnderecoDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(Endereco entity)
        {
            await _unitOfWork.EnderecoRepository.Create(entity);
        }

        public async Task Update(Endereco entity)
        {
            await _unitOfWork.EnderecoRepository.Update(entity);
        }

        public async Task Delete(Endereco entity)
        {
            await _unitOfWork.EnderecoRepository.Delete(entity);
        }

        public async Task<Endereco> Get(Guid id)
        {
            var endereco = await _unitOfWork.EnderecoRepository.Get(id);
            return endereco;
        }

        public async Task<IList<Endereco>> GetAll()
        {
            var enderecos = await _unitOfWork.EnderecoRepository.GetAll();
            return enderecos.ToList();
        }


    }
}
