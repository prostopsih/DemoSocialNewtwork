namespace DAL.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AvaSignature")]
    public partial class AvaSignature
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AvatarId { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual Avatar Avatar { get; set; }
    }
}
