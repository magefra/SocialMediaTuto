using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.src.Entities;
using SocialMedia.Core.src.Interfaces.Repositories;
using SocialMedia.Infrastructure.src.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.src.Repositories
{
    public class PostRepository : IPostRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly SocialMediaContext _socialMediaContext;


    
        public PostRepository(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public  async Task<IEnumerable<Post>> Get()
        {
            var post = await _socialMediaContext.Posts.ToListAsync();
            return post;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Post> getId(int id)
        {
            var post = await _socialMediaContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
            return post;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task add(Post post)
        {
           await _socialMediaContext.Posts.AddAsync(post);
           await _socialMediaContext.SaveChangesAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task<bool> Update(Post post)
        {
            var resultPost = await getId(post.Id);

            resultPost.Date = post.Date;
            resultPost.Description = post.Description;
            resultPost.Image = post.Image;



           int rows =  await _socialMediaContext.SaveChangesAsync();


            return rows > 0;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {
            var resultPost = await getId(id);

            _socialMediaContext.Posts.Remove(resultPost);


            int rows = await _socialMediaContext.SaveChangesAsync();


            return rows > 0;
        }
    }
}
