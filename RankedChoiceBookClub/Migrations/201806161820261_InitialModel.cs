namespace RankedChoiceBookClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookClubMeetings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Book_Id = c.Int(),
                        BookClub_Id = c.Int(),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.BookClubs", t => t.BookClub_Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.BookClub_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.BookClubs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AccessCode = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookVotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookClubMeeting_Id = c.Int(),
                        Choice1_Id = c.Int(),
                        Choice2_Id = c.Int(),
                        Choice3_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookClubMeetings", t => t.BookClubMeeting_Id)
                .ForeignKey("dbo.Books", t => t.Choice1_Id)
                .ForeignKey("dbo.Books", t => t.Choice2_Id)
                .ForeignKey("dbo.Books", t => t.Choice3_Id)
                .Index(t => t.BookClubMeeting_Id)
                .Index(t => t.Choice1_Id)
                .Index(t => t.Choice2_Id)
                .Index(t => t.Choice3_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookClubMeetings", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.BookVotes", "Choice3_Id", "dbo.Books");
            DropForeignKey("dbo.BookVotes", "Choice2_Id", "dbo.Books");
            DropForeignKey("dbo.BookVotes", "Choice1_Id", "dbo.Books");
            DropForeignKey("dbo.BookVotes", "BookClubMeeting_Id", "dbo.BookClubMeetings");
            DropForeignKey("dbo.BookClubMeetings", "BookClub_Id", "dbo.BookClubs");
            DropForeignKey("dbo.BookClubMeetings", "Book_Id", "dbo.Books");
            DropIndex("dbo.BookVotes", new[] { "Choice3_Id" });
            DropIndex("dbo.BookVotes", new[] { "Choice2_Id" });
            DropIndex("dbo.BookVotes", new[] { "Choice1_Id" });
            DropIndex("dbo.BookVotes", new[] { "BookClubMeeting_Id" });
            DropIndex("dbo.BookClubMeetings", new[] { "Location_Id" });
            DropIndex("dbo.BookClubMeetings", new[] { "BookClub_Id" });
            DropIndex("dbo.BookClubMeetings", new[] { "Book_Id" });
            DropTable("dbo.Locations");
            DropTable("dbo.BookVotes");
            DropTable("dbo.BookClubs");
            DropTable("dbo.BookClubMeetings");
        }
    }
}
