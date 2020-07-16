using SocialMedia.Core.src.Entities;
using SocialMedia.Core.src.Interfaces.Repositories;
using SocialMedia.Core.src.Interfaces.Services;
using SocialMedia.Core.src.Interfaces.UniOfWork;
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
        private readonly IUnitOfWork _unitOfWork;



        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task add(Post post)
        {
            var user = await _unitOfWork.UserRepository.GetById(post.UserId);

            if (user == null)
            {
                throw new Exception("El usuario no éxiste");
            }

            await _unitOfWork.PostRepository.Add(post);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async  Task<bool> Delete(int id)
        {
          await _unitOfWork.PostRepository.Delete(id);
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Post>> Get()
        {
            return await _unitOfWork.PostRepository.GetAll();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Post> getId(int id)
        {
            return  await _unitOfWork.PostRepository.GetById(id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task<bool> Update(Post post)
        {
           await _unitOfWork.PostRepository.Update(post);
            return true;
        }
    }
}
