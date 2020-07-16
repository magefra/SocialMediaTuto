using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.src.Entities;
using SocialMedia.Core.src.Interfaces.Repositories;
using SocialMedia.Infrastructure.src.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.src.Repositories
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly SocialMediaContext _socialMediaContext;



        public UserRepository(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> Get()
        {
            var user = await _socialMediaContext.Users.ToListAsync();
            return user;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> getId(int id)
        {
            var user = await _socialMediaContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

    }
}
