namespace DAL.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        public int PostId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Header { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual User User { get; set; }
    }
}
