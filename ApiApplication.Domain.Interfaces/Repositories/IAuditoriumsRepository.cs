using ApiApplication.Domain.Entities;

namespace ApiApplication.Domain.Interfaces.Repositories
{
    public interface IAuditoriumsRepository
    {
        Task<AuditoriumEntity> GetAsync(int auditoriumId, CancellationToken cancel);
    }
}