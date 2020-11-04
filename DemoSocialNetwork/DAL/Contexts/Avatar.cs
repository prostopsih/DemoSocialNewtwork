namespace DAL.Contexts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Avatar")]
    public partial class Avatar
    {
        public int AvatarId { get; set; }

        public int UserId { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public virtual AvaSignature AvaSignature { get; set; }

        public virtual User User { get; set; }
    }
}
