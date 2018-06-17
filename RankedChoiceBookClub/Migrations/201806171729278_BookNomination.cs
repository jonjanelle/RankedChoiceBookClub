namespace RankedChoiceBookClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookNomination : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookNominations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Book_Id = c.Int(),
                        BookClubMeeting_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.BookClubMeetings", t => t.BookClubMeeting_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.BookClubMeeting_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookNominations", "BookClubMeeting_Id", "dbo.BookClubMeetings");
            DropForeignKey("dbo.BookNominations", "Book_Id", "dbo.Books");
            DropIndex("dbo.BookNominations", new[] { "BookClubMeeting_Id" });
            DropIndex("dbo.BookNominations", new[] { "Book_Id" });
            DropTable("dbo.BookNominations");
        }
    }
}
