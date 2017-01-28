using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Domain.Core
{
    public class BuscomContext : DbContext
    {
        public BuscomContext() :base("CommunicationAppDb")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BuscomContext, Migrations.Configuration>("BusComDb"));
        }

        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Commit> Commits { get; set; }
        public DbSet<CommitChange> CommitChanges { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Project>()
                .HasMany<User>(x => x.Users)
                .WithMany(y => y.Projects)
                .Map(xy =>
                {
                    xy.MapLeftKey("ProjectId");
                    xy.MapRightKey("UserId");
                    xy.ToTable("ProjectsMembership");
                });

            modelBuilder.Entity<User>()
                .HasMany<ChatRoom>(x => x.ChatRooms)
                .WithMany(y => y.Users)
                .Map(xy =>
                {
                    xy.MapLeftKey("UserId");
                    xy.MapRightKey("ChatId");
                    xy.ToTable("ChatsUsers");
                });

            modelBuilder.Entity<Project>()
                .HasRequired<User>(x => x.Admin)
                .WithMany(y => y.AdminProjects)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<File>()
                .HasRequired<CommitChange>(x => x.CommitChange)
                .WithMany(y => y.Files);

            modelBuilder.Entity<Message>()
                .HasRequired<User>(x => x.Sender)
                .WithMany(y => y.SendedMessages);

            modelBuilder.Entity<User>()
                .Property(User.HashedExpression);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
