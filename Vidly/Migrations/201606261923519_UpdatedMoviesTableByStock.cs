namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMoviesTableByStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 55));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "Stock");
        }
    }
}
