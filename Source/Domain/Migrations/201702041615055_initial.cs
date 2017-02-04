namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        AttachmentId = c.Int(nullable: false),
                        FileContent = c.Binary(),
                        Extension = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AttachmentId)
                .ForeignKey("dbo.Messages", t => t.AttachmentId)
                .Index(t => t.AttachmentId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        PostDate = c.DateTime(nullable: false),
                        ChatId = c.Int(nullable: false),
                        Sender_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.ChatRooms", t => t.ChatId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Sender_Id, cascadeDelete: true)
                .Index(t => t.ChatId)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "dbo.ChatRooms",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        ChatName = c.String(),
                        Description = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChatId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        AdminId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.AspNetUsers", t => t.AdminId)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Commits",
                c => new
                    {
                        CommitId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommitId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileContent = c.Binary(),
                        Extension = c.String(maxLength: 4),
                        CommitId = c.Int(nullable: false),
                        CommitChange_ChangeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Commits", t => t.CommitId, cascadeDelete: true)
                .ForeignKey("dbo.CommitChanges", t => t.CommitChange_ChangeId, cascadeDelete: true)
                .Index(t => t.CommitId)
                .Index(t => t.CommitChange_ChangeId);
            
            CreateTable(
                "dbo.CommitChanges",
                c => new
                    {
                        ChangeId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ChangeId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ChatsUsers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        ChatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ChatId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.ChatRooms", t => t.ChatId)
                .Index(t => t.UserId)
                .Index(t => t.ChatId);
            
            CreateTable(
                "dbo.ProjectsMembership",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.UserId })
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ProjectId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Attachments", "AttachmentId", "dbo.Messages");
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ChatRooms", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectsMembership", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectsMembership", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Commits", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Files", "CommitChange_ChangeId", "dbo.CommitChanges");
            DropForeignKey("dbo.Files", "CommitId", "dbo.Commits");
            DropForeignKey("dbo.Projects", "AdminId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ChatsUsers", "ChatId", "dbo.ChatRooms");
            DropForeignKey("dbo.ChatsUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "ChatId", "dbo.ChatRooms");
            DropIndex("dbo.ProjectsMembership", new[] { "UserId" });
            DropIndex("dbo.ProjectsMembership", new[] { "ProjectId" });
            DropIndex("dbo.ChatsUsers", new[] { "ChatId" });
            DropIndex("dbo.ChatsUsers", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Files", new[] { "CommitChange_ChangeId" });
            DropIndex("dbo.Files", new[] { "CommitId" });
            DropIndex("dbo.Commits", new[] { "ProjectId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Projects", new[] { "AdminId" });
            DropIndex("dbo.ChatRooms", new[] { "ProjectId" });
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropIndex("dbo.Messages", new[] { "ChatId" });
            DropIndex("dbo.Attachments", new[] { "AttachmentId" });
            DropTable("dbo.ProjectsMembership");
            DropTable("dbo.ChatsUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.CommitChanges");
            DropTable("dbo.Files");
            DropTable("dbo.Commits");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Projects");
            DropTable("dbo.ChatRooms");
            DropTable("dbo.Messages");
            DropTable("dbo.Attachments");
        }
    }
}
