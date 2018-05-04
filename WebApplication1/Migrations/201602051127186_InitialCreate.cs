namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        PositionId = c.Int(),
                        DateOfBirth = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionId)
                .Index(t => t.PositionId);
            
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
            DropForeignKey("dbo.Contacts", "PositionId", "dbo.Positions");
            DropIndex("dbo.Contacts", new[] { "PositionId" });
            DropTable("dbo.Positions");
            DropTable("dbo.Contacts");
        }
    }
}
