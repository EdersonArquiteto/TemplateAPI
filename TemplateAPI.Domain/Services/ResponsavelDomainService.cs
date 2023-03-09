using TemplateAPI.Domain.Entities;
using TemplateAPI.Domain.Interfaces.Repositories;
using TemplateAPI.Domain.Interfaces.Services;

namespace TemplateAPI.Domain.Services
{
    public class ResponsavelDomainService : IBaseDomainService<Responsavel, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResponsavelDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Responsavel entity)
        {
            await _unitOfWork.ResponsavelRepository.Create(entity);
        }
        public async Task Update(Responsavel entity)
        {
            await _unitOfWork.ResponsavelRepository.Update(entity);
        }

        public async Task Delete(Responsavel entity)
        {
            await _unitOfWork.ResponsavelRepository.Delete(entity);
        }

        public async Task<Responsavel> Get(Guid id)
        {
            var responsavel = await _unitOfWork.ResponsavelRepository.Get(id);
            return responsavel;
        }

        public async Task<IList<Responsavel>> GetAll()
        {
            var responsaveis = await _unitOfWork.ResponsavelRepository.GetAll();
            return responsaveis.ToList();
        }


    }
}
