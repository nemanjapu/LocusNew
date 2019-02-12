namespace LocusNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModelUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BookAShowings", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.Listings", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.BookAShowings", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
            RenameIndex(table: "dbo.Listings", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "isAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "isAgent", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "isDev", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "isActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "ImageName", c => c.String());
            AddColumn("dbo.AspNetUsers", "ImagePath", c => c.String());
            AddColumn("dbo.AspNetUsers", "AgentCardImageName", c => c.String());
            AddColumn("dbo.AspNetUsers", "AgentCardImagePath", c => c.String());
            AddColumn("dbo.AspNetUsers", "Designation", c => c.String());
            DropColumn("dbo.BookAShowings", "UserId");
            DropColumn("dbo.Listings", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Listings", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.BookAShowings", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Designation");
            DropColumn("dbo.AspNetUsers", "AgentCardImagePath");
            DropColumn("dbo.AspNetUsers", "AgentCardImageName");
            DropColumn("dbo.AspNetUsers", "ImagePath");
            DropColumn("dbo.AspNetUsers", "ImageName");
            DropColumn("dbo.AspNetUsers", "isActive");
            DropColumn("dbo.AspNetUsers", "isDev");
            DropColumn("dbo.AspNetUsers", "isAgent");
            DropColumn("dbo.AspNetUsers", "isAdmin");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            RenameIndex(table: "dbo.Listings", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.BookAShowings", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Listings", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.BookAShowings", name: "ApplicationUserId", newName: "ApplicationUser_Id");
        }
    }
}
