namespace QuizProgramMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuizSchemaChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "QuestionDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Question", "QuestionVersionDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Question", "QuestionVersionDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Question", "QuestionDate");
        }
    }
}
