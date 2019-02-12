namespace LocusNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookAShowings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        DateSubmited = c.DateTime(nullable: false),
                        DateForShowing = c.DateTime(nullable: false),
                        ListingId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Listings", t => t.ListingId, cascadeDelete: true)
                .Index(t => t.ListingId)
                .Index(t => t.ApplicationUser_Id);
            
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
                "dbo.Listings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Details = c.String(),
                        LeaseSaleId = c.Int(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        isSold = c.Boolean(nullable: false),
                        ListingTypeId = c.Int(nullable: false),
                        Published = c.DateTime(nullable: false),
                        Floor = c.Int(nullable: false),
                        TotalFloorNumber = c.Int(nullable: false),
                        LotSquareMeters = c.Int(nullable: false),
                        YardSquareMeters = c.Int(nullable: false),
                        YearBuilt = c.Int(nullable: false),
                        YearOfLastAdaptation = c.Int(nullable: false),
                        Elevator = c.Boolean(nullable: false),
                        Balcony = c.Boolean(nullable: false),
                        Terrace = c.Boolean(nullable: false),
                        Loggia = c.Boolean(nullable: false),
                        Attic = c.Boolean(nullable: false),
                        Basement = c.Boolean(nullable: false),
                        Pantry = c.Boolean(nullable: false),
                        Water = c.Boolean(nullable: false),
                        Gas = c.Boolean(nullable: false),
                        Canalization = c.String(),
                        TelephoneConnection = c.Boolean(nullable: false),
                        Electricity = c.Boolean(nullable: false),
                        CentralHeatingToplane = c.Boolean(nullable: false),
                        CentralHeatingEtazno = c.String(),
                        CableTV = c.Boolean(nullable: false),
                        Internet = c.Boolean(nullable: false),
                        Furniture = c.Boolean(nullable: false),
                        Latidute = c.String(),
                        Longitude = c.String(),
                        UserId = c.Int(nullable: false),
                        CityPartId = c.Int(nullable: false),
                        Toilete = c.Int(nullable: false),
                        HouseOwnerId = c.Int(nullable: false),
                        ListingUniqueCode = c.String(),
                        MetaKeyWords = c.String(),
                        NotesForAgents = c.String(),
                        SourceId = c.Int(),
                        CommissionFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinanceType = c.String(),
                        Videophone = c.Boolean(nullable: false),
                        Interphone = c.Boolean(nullable: false),
                        PrivateParking = c.Boolean(nullable: false),
                        Garage = c.Boolean(nullable: false),
                        ArmoredDoor = c.Boolean(nullable: false),
                        ClientPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Heading = c.String(),
                        AirConditioner = c.Boolean(nullable: false),
                        Joinery = c.String(),
                        NewKitchen = c.Boolean(nullable: false),
                        ContractFrom = c.DateTime(nullable: false),
                        ContractTo = c.DateTime(nullable: false),
                        FloorText = c.String(),
                        AlternativeHeating = c.String(),
                        isReserved = c.Boolean(nullable: false),
                        MultiBedrooms = c.Boolean(nullable: false),
                        MultiBathrooms = c.Boolean(nullable: false),
                        MultiSquareMeters = c.Boolean(nullable: false),
                        MultiBedroomsFrom = c.Int(),
                        MultiBedroomsTo = c.Int(),
                        MultiBathFrom = c.Int(),
                        MultiBathTo = c.Int(),
                        MultiSquareMetersFrom = c.Int(),
                        MultiSquareMetersTo = c.Int(),
                        MultiPrice = c.Boolean(nullable: false),
                        MultiPriceFrom = c.Decimal(precision: 18, scale: 2),
                        MultiPriceTo = c.Decimal(precision: 18, scale: 2),
                        MultiRooms = c.Boolean(nullable: false),
                        MultiRoomsFrom = c.Int(),
                        MultiRoomsTo = c.Int(),
                        Rooms = c.Int(),
                        Bedrooms = c.Int(),
                        Bathrooms = c.Int(),
                        SquareMeters = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        AdType_Id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        PropertyType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdTypes", t => t.AdType_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.CityParts", t => t.CityPartId, cascadeDelete: true)
                .ForeignKey("dbo.PropertyOwners", t => t.HouseOwnerId, cascadeDelete: true)
                .ForeignKey("dbo.PropertyTypes", t => t.PropertyType_Id)
                .ForeignKey("dbo.Sources", t => t.SourceId)
                .Index(t => t.CityPartId)
                .Index(t => t.HouseOwnerId)
                .Index(t => t.SourceId)
                .Index(t => t.AdType_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.PropertyType_Id);
            
            CreateTable(
                "dbo.CityParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PropertyOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        IdNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ListingImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Extension = c.String(),
                        ListingId = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        FileNameNoExt = c.String(),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listings", t => t.ListingId, cascadeDelete: true)
                .Index(t => t.ListingId);
            
            CreateTable(
                "dbo.PropertyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GlobalSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        AboutUs = c.String(nullable: false),
                        FacebookLink = c.String(),
                        InstagramLink = c.String(),
                        TwitterLink = c.String(),
                        PinterestLink = c.String(),
                        GooglePlusLink = c.String(),
                        LinkedinLink = c.String(),
                        YoutubeLink = c.String(),
                        CityPart1Id = c.Int(nullable: false),
                        CityPart1Image = c.String(),
                        Image1path = c.String(),
                        CityPart2Id = c.Int(nullable: false),
                        CityPart2Image = c.String(),
                        Image2path = c.String(),
                        CityPart3Id = c.Int(nullable: false),
                        CityPart3Image = c.String(),
                        Image3path = c.String(),
                        CityPart4Id = c.Int(nullable: false),
                        CityPart4Image = c.String(),
                        Image4path = c.String(),
                        CityPart5Id = c.Int(nullable: false),
                        CityPart5Image = c.String(),
                        Image5path = c.String(),
                        CityPart6Id = c.Int(nullable: false),
                        CityPart6Image = c.String(),
                        Image6path = c.String(),
                        FaxNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Leads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PropertyBuyers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        ListingId = c.Int(),
                        IdNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Listings", t => t.ListingId)
                .Index(t => t.ListingId);
            
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
                "dbo.SellerLeads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        SquareMeters = c.Int(nullable: false),
                        ListingTypeId = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                        Address = c.String(),
                        Date = c.DateTime(nullable: false),
                        Elevator = c.Boolean(nullable: false),
                        Balcony = c.Boolean(nullable: false),
                        FeeWanted = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsSelling = c.Boolean(nullable: false),
                        IsRepurchasing = c.Boolean(nullable: false),
                        PropertyType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyTypes", t => t.PropertyType_Id)
                .Index(t => t.PropertyType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SellerLeads", "PropertyType_Id", "dbo.PropertyTypes");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PropertyBuyers", "ListingId", "dbo.Listings");
            DropForeignKey("dbo.BookAShowings", "ListingId", "dbo.Listings");
            DropForeignKey("dbo.Listings", "SourceId", "dbo.Sources");
            DropForeignKey("dbo.Listings", "PropertyType_Id", "dbo.PropertyTypes");
            DropForeignKey("dbo.ListingImages", "ListingId", "dbo.Listings");
            DropForeignKey("dbo.Listings", "HouseOwnerId", "dbo.PropertyOwners");
            DropForeignKey("dbo.Listings", "CityPartId", "dbo.CityParts");
            DropForeignKey("dbo.Listings", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Listings", "AdType_Id", "dbo.AdTypes");
            DropForeignKey("dbo.BookAShowings", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.SellerLeads", new[] { "PropertyType_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PropertyBuyers", new[] { "ListingId" });
            DropIndex("dbo.ListingImages", new[] { "ListingId" });
            DropIndex("dbo.Listings", new[] { "PropertyType_Id" });
            DropIndex("dbo.Listings", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Listings", new[] { "AdType_Id" });
            DropIndex("dbo.Listings", new[] { "SourceId" });
            DropIndex("dbo.Listings", new[] { "HouseOwnerId" });
            DropIndex("dbo.Listings", new[] { "CityPartId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.BookAShowings", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.BookAShowings", new[] { "ListingId" });
            DropTable("dbo.SellerLeads");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PropertyBuyers");
            DropTable("dbo.Leads");
            DropTable("dbo.GlobalSettings");
            DropTable("dbo.Sources");
            DropTable("dbo.PropertyTypes");
            DropTable("dbo.ListingImages");
            DropTable("dbo.PropertyOwners");
            DropTable("dbo.CityParts");
            DropTable("dbo.Listings");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.BookAShowings");
            DropTable("dbo.AdTypes");
        }
    }
}
