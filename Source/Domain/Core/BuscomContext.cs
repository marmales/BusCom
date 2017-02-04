using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Core
{
    public class BuscomContext : IdentityDbContext<User>
    {
        public BuscomContext() :base("IdentityDb")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BuscomContext, Migrations.Configuration>("BusComDb"));
        }

        static BuscomContext()
        {
            Database.SetInitializer<BuscomContext>(new IdentityDbInit());
        }
        public static BuscomContext Create()
        {
            return new BuscomContext();
        }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Commit> Commits { get; set; }
        public DbSet<CommitChange> CommitChanges { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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


            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public class IdentityDbInit: DropCreateDatabaseIfModelChanges<BuscomContext>
        {
            protected override void Seed(BuscomContext context)
            {
                PerformInitialSetup(context);
                base.Seed(context);
            }
            public void PerformInitialSetup(BuscomContext context)
            {
                //throw new NotImplementedException();
            }
        }
    }
}
