namespace ContactsAdminApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableDateOfBirth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
