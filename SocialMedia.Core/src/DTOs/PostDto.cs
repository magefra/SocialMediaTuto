using System;

namespace SocialMedia.Core.src.DTOs
{
    public class PostDto
    {
        /// <summary>
        /// Id Autoincremental.
        /// </summary>
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
