using SocialMedia.Core.src.Entities;
using SocialMedia.Core.src.Exceptions;
using SocialMedia.Core.src.Interfaces.Services;
using SocialMedia.Core.src.Interfaces.UniOfWork;
using SocialMedia.Core.src.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
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
                throw new BusinessException("El usuario no éxiste");
            }

            var userPost = await _unitOfWork.PostRepository.GetByUserAsync(post.UserId);


            if(userPost.Count() < 100)
            {
                //Obtener el ultimo Post.
                var lastPost = userPost.OrderByDescending(x => x.Date).LastOrDefault();


                if ((lastPost.Date - DateTime.Now).TotalDays < 7)
                {
                    throw new BusinessException("No puedes publicar una publicación");
                }
            }


            //Faltaría otra validación


            await _unitOfWork.PostRepository.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Post> Get(PostQueryFilter filters)
        {

            var post = _unitOfWork.PostRepository.GetAll(); 

            if(filters.UserId != null)
            {
                post = post.Where(x => x.UserId == filters.UserId);
            }

            if (filters.Date != null)
            {
                post = post.Where(
                    x => x.Date.ToShortDateString() == filters.Date?.ToShortDateString());
            }

            if (filters.Description != null)
            {
                post = post.Where(
                    x => x.Description.ToLower() == filters.Description.ToLower());
            }

            return post;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Post> getId(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task<bool> Update(Post post)
        {
            _unitOfWork.PostRepository.Update(post);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
