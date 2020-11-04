namespace DAL.Contexts
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DemoSocialNetworkContext : DbContext
    {
        public DemoSocialNetworkContext()
            : base("name=DemoSocialNetworkContext")
        {
        }

        public virtual DbSet<AvaSignature> AvaSignature { get; set; }
        public virtual DbSet<Avatar> Avatar { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avatar>()
                .HasOptional(e => e.AvaSignature)
                .WithRequired(e => e.Avatar);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Avatar)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Post)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
