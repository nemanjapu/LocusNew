namespace LocusNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModelUpdate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Listings", "AdType_Id", "dbo.AdTypes");
            DropForeignKey("dbo.Listings", "PropertyType_Id", "dbo.PropertyTypes");
            DropForeignKey("dbo.SellerLeads", "PropertyType_Id", "dbo.PropertyTypes");
            DropIndex("dbo.Listings", new[] { "AdType_Id" });
            DropIndex("dbo.Listings", new[] { "PropertyType_Id" });
            DropIndex("dbo.SellerLeads", new[] { "PropertyType_Id" });
            RenameColumn(table: "dbo.Listings", name: "AdType_Id", newName: "AdTypeId");
            RenameColumn(table: "dbo.Listings", name: "PropertyType_Id", newName: "PropertyTypeId");
            RenameColumn(table: "dbo.SellerLeads", name: "PropertyType_Id", newName: "PropertyTypeId");
            RenameColumn(table: "dbo.Listings", name: "HouseOwnerId", newName: "PropertyOwnerId");
            RenameIndex(table: "dbo.Listings", name: "IX_HouseOwnerId", newName: "IX_PropertyOwnerId");
            AlterColumn("dbo.Listings", "AdTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Listings", "PropertyTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.SellerLeads", "PropertyTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Listings", "AdTypeId");
            CreateIndex("dbo.Listings", "PropertyTypeId");
            CreateIndex("dbo.SellerLeads", "PropertyTypeId");
            AddForeignKey("dbo.Listings", "AdTypeId", "dbo.AdTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Listings", "PropertyTypeId", "dbo.PropertyTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SellerLeads", "PropertyTypeId", "dbo.PropertyTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Listings", "LeaseSaleId");
            DropColumn("dbo.Listings", "ListingTypeId");
            DropColumn("dbo.SellerLeads", "ListingTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SellerLeads", "ListingTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Listings", "ListingTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Listings", "LeaseSaleId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SellerLeads", "PropertyTypeId", "dbo.PropertyTypes");
            DropForeignKey("dbo.Listings", "PropertyTypeId", "dbo.PropertyTypes");
            DropForeignKey("dbo.Listings", "AdTypeId", "dbo.AdTypes");
            DropIndex("dbo.SellerLeads", new[] { "PropertyTypeId" });
            DropIndex("dbo.Listings", new[] { "PropertyTypeId" });
            DropIndex("dbo.Listings", new[] { "AdTypeId" });
            AlterColumn("dbo.SellerLeads", "PropertyTypeId", c => c.Int());
            AlterColumn("dbo.Listings", "PropertyTypeId", c => c.Int());
            AlterColumn("dbo.Listings", "AdTypeId", c => c.Int());
            RenameIndex(table: "dbo.Listings", name: "IX_PropertyOwnerId", newName: "IX_HouseOwnerId");
            RenameColumn(table: "dbo.Listings", name: "PropertyOwnerId", newName: "HouseOwnerId");
            RenameColumn(table: "dbo.SellerLeads", name: "PropertyTypeId", newName: "PropertyType_Id");
            RenameColumn(table: "dbo.Listings", name: "PropertyTypeId", newName: "PropertyType_Id");
            RenameColumn(table: "dbo.Listings", name: "AdTypeId", newName: "AdType_Id");
            CreateIndex("dbo.SellerLeads", "PropertyType_Id");
            CreateIndex("dbo.Listings", "PropertyType_Id");
            CreateIndex("dbo.Listings", "AdType_Id");
            AddForeignKey("dbo.SellerLeads", "PropertyType_Id", "dbo.PropertyTypes", "Id");
            AddForeignKey("dbo.Listings", "PropertyType_Id", "dbo.PropertyTypes", "Id");
            AddForeignKey("dbo.Listings", "AdType_Id", "dbo.AdTypes", "Id");
        }
    }
}
