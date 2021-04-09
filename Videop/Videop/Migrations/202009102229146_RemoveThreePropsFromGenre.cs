namespace Videop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveThreePropsFromGenre : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Genres", "ReleaseDate");
            DropColumn("dbo.Genres", "DateAdded");
            DropColumn("dbo.Genres", "NumberInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "NumberInStock", c => c.Short(nullable: false));
            AddColumn("dbo.Genres", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Genres", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
