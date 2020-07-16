using SocialMedia.Core.src.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.src.Interfaces.Repositories
{
    public interface IUserRepository
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
         Task<IEnumerable<User>> Get();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> getId(int id);
    }
}
