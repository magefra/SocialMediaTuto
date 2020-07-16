using SocialMedia.Core.src.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.src.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById(int id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Add(T entity);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Update(T entity);



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);

    }
}
