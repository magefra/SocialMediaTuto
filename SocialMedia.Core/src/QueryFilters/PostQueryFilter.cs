using System;

namespace SocialMedia.Core.src.QueryFilters
{
    public class PostQueryFilter
    {
        public int? UserId { get; set; }

        public DateTime? Date { get; set; }

        public String Description { get; set; }

        public int PageSize { get; set; }

        public int PageNumer { get; set; }



    }
}
