using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.src.Entities;
using SocialMedia.Core.src.Interfaces.Repositories;
using SocialMedia.Infrastructure.src.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
        protected DbSet<T> _entities;



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
          await  _entities.AddAsync(entity);
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
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return  _entities.AsEnumerable();
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
        public void Update(T entity)
        {
            _entities.Update(entity);
        }
    }
}
