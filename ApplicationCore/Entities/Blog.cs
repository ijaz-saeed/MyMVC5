using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        //[ConcurrencyCheck]
        [MaxLength(50)]
        public string Url { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
