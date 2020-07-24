using Microsoft.Extensions.Options;
using SocialMedia.Core.src.CustomEntities;
using SocialMedia.Core.src.Entities;
using SocialMedia.Core.src.Interfaces.Services;
using SocialMedia.Core.src.Interfaces.UniOfWork;
using System.Threading.Tasks;

namespace SocialMedia.Core.src.Services
{
    public class SecurityService : ISecurityService
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;


        /// <summary>
        /// 
        /// </summary>
        private readonly PaginationOptions _paginationOptions;




        public SecurityService(IUnitOfWork unitOfWork,
                           IOptions<PaginationOptions> paginationOptions)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = paginationOptions.Value;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userLoging"></param>
        /// <returns></returns>
        public  async Task<Security> GetLoggingByCredentials(UserLogin userLoging) 
        {
            return await _unitOfWork.SecurityRepository.GetLoginByCredentials(userLoging);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="security"></param>
        /// <returns></returns>
        public async Task RegisterUser(Security security)
        {
            await _unitOfWork.SecurityRepository.Add(security);
            await _unitOfWork.SaveChangesAsync();

        }





    }
}
