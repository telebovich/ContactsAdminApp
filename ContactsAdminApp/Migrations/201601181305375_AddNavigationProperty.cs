namespace ContactsAdminApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNavigationProperty : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Contacts", name: "Position_Id", newName: "PositionId");
            RenameIndex(table: "dbo.Contacts", name: "IX_Position_Id", newName: "IX_PositionId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Contacts", name: "IX_PositionId", newName: "IX_Position_Id");
            RenameColumn(table: "dbo.Contacts", name: "PositionId", newName: "Position_Id");
        }
    }
}
