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
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly SocialMediaContext _socialMediaContext;


        /// <summary>
        /// 
        /// </summary>
        private DbSet<T> _entities;



        public BaseRepository(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
            _entities = socialMediaContext.Set<T>();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task Add(T entity)
        {
            _entities.Add(entity);
           await _socialMediaContext.SaveChangesAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
           await _socialMediaContext.SaveChangesAsync();
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Update(T entity)
        {
            _entities.Update(entity);
            await _socialMediaContext.SaveChangesAsync();
        }
    }
}
