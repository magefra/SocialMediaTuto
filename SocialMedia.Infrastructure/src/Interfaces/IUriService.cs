using SocialMedia.Core.src.QueryFilters;
using System;

namespace SocialMedia.Infrastructure.src.Interfaces
{
    public interface IUriService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="actionUri"></param>
        /// <returns></returns>
        Uri GetPostPaginationUri(PostQueryFilter filter,
                                       string actionUri);
    }
}
