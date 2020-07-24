using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.src.Entities;
using SocialMedia.Core.src.Interfaces.Repositories;
using SocialMedia.Infrastructure.src.Data;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.src.Repositories
{
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {


        public SecurityRepository(SocialMediaContext context) : base(context) { }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.User == login.User);
        }
    }
}
