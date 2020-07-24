using SocialMedia.Core.src.Entities;
using System.Threading.Tasks;

namespace SocialMedia.Core.src.Interfaces.Services
{
    public interface ISecurityService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userLoging"></param>
        /// <returns></returns>
        Task<Security> GetLoggingByCredentials(UserLogin userLoging);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="security"></param>
        /// <returns></returns>
        Task RegisterUser(Security security);
    }
}
