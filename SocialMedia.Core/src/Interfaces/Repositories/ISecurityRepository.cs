using SocialMedia.Core.src.Entities;
using System.Threading.Tasks;

namespace SocialMedia.Core.src.Interfaces.Repositories
{
    public interface ISecurityRepository : IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}
