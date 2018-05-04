namespace ContactsAdminApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onetoonerelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        LandlinePhone = c.String(),
                        CellPhone = c.String(),
                        ImageUrl = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Position_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.Position_Id)
                .Index(t => t.Position_Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "Position_Id", "dbo.Positions");
            DropIndex("dbo.Contacts", new[] { "Position_Id" });
            DropTable("dbo.Positions");
            DropTable("dbo.Contacts");
        }
    }
}
