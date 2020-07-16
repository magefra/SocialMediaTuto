using SocialMedia.Core.src.Entities;
using SocialMedia.Core.src.Interfaces.Repositories;
using SocialMedia.Core.src.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.src.Services
{
    public class PostService : IPostService
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Post> _postRepository;


        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<User> _userRepository;





        public PostService(IRepository<Post> postRepository, IRepository<User> userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task add(Post post)
        {
            var user = await _userRepository.GetById(post.UserId);

            if (user == null)
            {
                throw new Exception("El usuario no éxiste");
            }

            await _postRepository.Add(post);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async  Task<bool> Delete(int id)
        {
          await   _postRepository.Delete(id);
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Post>> Get()
        {
            return await  _postRepository.GetAll();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Post> getId(int id)
        {
            return  await _postRepository.GetById(id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task<bool> Update(Post post)
        {
           await _postRepository.Update(post);
            return true;
        }
    }
}
