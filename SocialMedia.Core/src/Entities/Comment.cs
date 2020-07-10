using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.src.Entities
{
    public class Comment : BaseEntity
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
