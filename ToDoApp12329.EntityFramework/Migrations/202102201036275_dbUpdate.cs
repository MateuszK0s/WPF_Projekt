namespace ToDoApp12329.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskItems", "TaskDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaskItems", "TaskDate");
        }
    }
}
