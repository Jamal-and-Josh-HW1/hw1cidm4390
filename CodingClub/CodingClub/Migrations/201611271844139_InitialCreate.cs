namespace QuizProgramMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        AnswerText = c.String(),
                        AnswerJustification = c.String(),
                        QuestionRating = c.Single(nullable: false),
                        QuestionVersionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionAsked",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(nullable: false),
                        AskedDate = c.DateTime(nullable: false),
                        Question_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.Question_Id)
                .ForeignKey("dbo.Student", t => t.Student_Id)
                .ForeignKey("dbo.Quiz", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.QuizId)
                .Index(t => t.Question_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Correct = c.Int(nullable: false),
                        Attempts = c.Int(nullable: false),
                        Score = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Quiz",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionAsked", "QuizId", "dbo.Quiz");
            DropForeignKey("dbo.QuestionAsked", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.QuestionAsked", "Question_Id", "dbo.Question");
            DropIndex("dbo.QuestionAsked", new[] { "Student_Id" });
            DropIndex("dbo.QuestionAsked", new[] { "Question_Id" });
            DropIndex("dbo.QuestionAsked", new[] { "QuizId" });
            DropTable("dbo.Quiz");
            DropTable("dbo.Student");
            DropTable("dbo.QuestionAsked");
            DropTable("dbo.Question");
        }
    }
}
