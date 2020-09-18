using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMvc5.Models
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

    public class Post
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        
        [ForeignKey("BlogId")]
        public Blog Blog { get; set; } 
    }
}