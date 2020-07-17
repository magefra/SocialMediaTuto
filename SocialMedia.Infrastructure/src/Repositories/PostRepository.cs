using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.src.Entities;
using SocialMedia.Core.src.Interfaces.Repositories;
using SocialMedia.Infrastructure.src.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.src.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {



        public PostRepository(SocialMediaContext socialMediaContext) : base(socialMediaContext)
        {
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Post>> GetByUserAsync(int userId)
        {
            return await _entities.Where(x => x.UserId == userId).ToListAsync();
        }

    }
}
