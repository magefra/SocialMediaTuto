using SocialMedia.Core.src.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.src.Interfaces.Repositories
{
    public interface IPostRepository  : IRepository<Post>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetByUserAsync(int userId);
    }
}
