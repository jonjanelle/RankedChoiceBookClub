namespace RankedChoiceBookClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookClubIdToBookClubMeeting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookClubMeetings", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.BookNominations", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.BookNominations", "BookClubMeeting_Id", "dbo.BookClubMeetings");
            DropForeignKey("dbo.BookVotes", "BookClubMeeting_Id", "dbo.BookClubMeetings");
            DropForeignKey("dbo.BookClubMeetings", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.BookClubMeetings", "BookClub_Id", "dbo.BookClubs");
            DropIndex("dbo.BookClubMeetings", new[] { "Book_Id" });
            DropIndex("dbo.BookClubMeetings", new[] { "BookClub_Id" });
            DropIndex("dbo.BookClubMeetings", new[] { "Location_Id" });
            DropIndex("dbo.BookNominations", new[] { "Book_Id" });
            DropIndex("dbo.BookNominations", new[] { "BookClubMeeting_Id" });
            DropIndex("dbo.BookVotes", new[] { "BookClubMeeting_Id" });
            RenameColumn(table: "dbo.BookClubMeetings", name: "BookClub_Id", newName: "BookClubId");
            AddColumn("dbo.BookClubMeetings", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.BookClubMeetings", "BookId", c => c.Int(nullable: false));
            AddColumn("dbo.BookVotes", "BookClubMeetingId", c => c.Int(nullable: false));
            AlterColumn("dbo.BookClubMeetings", "BookClubId", c => c.Int(nullable: false));
            CreateIndex("dbo.BookClubMeetings", "BookClubId");
            AddForeignKey("dbo.BookClubMeetings", "BookClubId", "dbo.BookClubs", "Id", cascadeDelete: true);
            DropColumn("dbo.BookClubMeetings", "Book_Id");
            DropColumn("dbo.BookClubMeetings", "Location_Id");
            DropColumn("dbo.BookVotes", "BookClubMeeting_Id");
            DropTable("dbo.BookNominations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookNominations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Book_Id = c.Int(),
                        BookClubMeeting_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BookVotes", "BookClubMeeting_Id", c => c.Int());
            AddColumn("dbo.BookClubMeetings", "Location_Id", c => c.Int());
            AddColumn("dbo.BookClubMeetings", "Book_Id", c => c.Int());
            DropForeignKey("dbo.BookClubMeetings", "BookClubId", "dbo.BookClubs");
            DropIndex("dbo.BookClubMeetings", new[] { "BookClubId" });
            AlterColumn("dbo.BookClubMeetings", "BookClubId", c => c.Int());
            DropColumn("dbo.BookVotes", "BookClubMeetingId");
            DropColumn("dbo.BookClubMeetings", "BookId");
            DropColumn("dbo.BookClubMeetings", "LocationId");
            RenameColumn(table: "dbo.BookClubMeetings", name: "BookClubId", newName: "BookClub_Id");
            CreateIndex("dbo.BookVotes", "BookClubMeeting_Id");
            CreateIndex("dbo.BookNominations", "BookClubMeeting_Id");
            CreateIndex("dbo.BookNominations", "Book_Id");
            CreateIndex("dbo.BookClubMeetings", "Location_Id");
            CreateIndex("dbo.BookClubMeetings", "BookClub_Id");
            CreateIndex("dbo.BookClubMeetings", "Book_Id");
            AddForeignKey("dbo.BookClubMeetings", "BookClub_Id", "dbo.BookClubs", "Id");
            AddForeignKey("dbo.BookClubMeetings", "Location_Id", "dbo.Locations", "Id");
            AddForeignKey("dbo.BookVotes", "BookClubMeeting_Id", "dbo.BookClubMeetings", "Id");
            AddForeignKey("dbo.BookNominations", "BookClubMeeting_Id", "dbo.BookClubMeetings", "Id");
            AddForeignKey("dbo.BookNominations", "Book_Id", "dbo.Books", "Id");
            AddForeignKey("dbo.BookClubMeetings", "Book_Id", "dbo.Books", "Id");
        }
    }
}
