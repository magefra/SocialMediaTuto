using SocialMedia.Core.src.Entities;
using SocialMedia.Core.src.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace SocialMedia.Core.src.Interfaces.UniOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// 
        /// </summary>
        IRepository<Post> PostRepository { get;  }


        /// <summary>
        /// 
        /// </summary>
        IRepository<User> UserRepository { get; }



        /// <summary>
        /// 
        /// </summary>
        IRepository<Comment> CommentRepository { get; }



        /// <summary>
        /// 
        /// </summary>
        void SaveChanges();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();


    }
}
