using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Core.src.CustomEntities
{
    public class PageList<T> : List<T>
    {
        /// <summary>
        /// Página actual
        /// </summary>
        public int CurrentPage { get; set; }


        /// <summary>
        /// Total de paginas
        /// </summary>
        public int TotalPages { get; set; }


        /// <summary>
        /// Tamaño por pagina.
        /// </summary>
        public int PageSize { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public int TotalCount { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public bool HasPreviusPage => CurrentPage > 1;


        /// <summary>
        /// 
        /// </summary>
        public bool HasNextPage => CurrentPage < TotalPages;

        /// <summary>
        /// 
        /// </summary>
        public int? NextPageNumer => HasNextPage ? CurrentPage + 1 : (int?)null;


        /// <summary>
        /// 
        /// </summary>
        public int? PreviosPageNumer => HasPreviusPage ? CurrentPage - 1 : (int?)null;



        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sources"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PageList<T> Create(IEnumerable<T> sources, int pageNumber, int pageSize)
        {
            var count = sources.Count();
            var items = sources.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PageList<T>(items, count, pageNumber, pageSize);

        }

    }
}
