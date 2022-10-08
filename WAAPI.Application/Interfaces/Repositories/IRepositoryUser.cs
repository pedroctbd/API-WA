using WAAPI.Domain.Entities;

namespace WAAPI.Application.Interfaces
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        Task<User> GetUserByEmail(string Email);

    }
}