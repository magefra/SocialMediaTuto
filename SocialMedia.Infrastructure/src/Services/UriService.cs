using SocialMedia.Core.src.QueryFilters;
using SocialMedia.Infrastructure.src.Interfaces;
using System;

namespace SocialMedia.Infrastructure.src.Services
{
    public class UriService : IUriService
    {

        private readonly string _baseURI;


        public UriService(string baseURI)
        {
            _baseURI = baseURI;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="actionUri"></param>
        /// <returns></returns>
        public Uri GetPostPaginationUri(PostQueryFilter filter,
                                        string actionUri)
        {
            string baseUrl = $"{_baseURI}{actionUri}";

            return new Uri(baseUrl);
        }


    }
}
