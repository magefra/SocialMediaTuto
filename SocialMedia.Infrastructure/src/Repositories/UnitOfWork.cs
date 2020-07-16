using SocialMedia.Core.src.Entities;
using SocialMedia.Core.src.Interfaces.Repositories;
using SocialMedia.Core.src.Interfaces.UniOfWork;
using SocialMedia.Infrastructure.src.Data;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.src.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly SocialMediaContext _socialMediaContext;


        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Post> _postRepository;


        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<User> _userRepository;


        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<Comment> _commentRepository;




        public UnitOfWork(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }



        /// <summary>
        /// 
        /// </summary>
        public IRepository<Post> PostRepository => _postRepository ?? new BaseRepository<Post>(_socialMediaContext);

        /// <summary>
        /// 
        /// </summary>
        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_socialMediaContext);


        /// <summary>
        /// 
        /// </summary>
        public IRepository<Comment> CommentRepository => _commentRepository ?? new BaseRepository<Comment>(_socialMediaContext);




        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if(_socialMediaContext != null)
            {
                _socialMediaContext.Dispose();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void SaveChanges()
        {
            _socialMediaContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _socialMediaContext.SaveChangesAsync();
        }
    }
}
