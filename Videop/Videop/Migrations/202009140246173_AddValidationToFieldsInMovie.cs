namespace Videop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationToFieldsInMovie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
        }
    }
}
