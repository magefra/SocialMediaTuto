using SocialMedia.Core.src.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.src.Interfaces.Repositories
{
    public interface IPostRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Post>> Get();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Post> getId(int id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Task add(Post post);
    }
}
