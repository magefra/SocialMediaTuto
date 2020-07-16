using SocialMedia.Core.src.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.src.Interfaces.Services
{
    public interface IPostService
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Task<bool> Update(Post post);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(int id);
    }
}