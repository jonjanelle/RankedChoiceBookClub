namespace RankedChoiceBookClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookClubIdToBookClubMeeting1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BookClubMeetings", "LocationId");
            AddForeignKey("dbo.BookClubMeetings", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookClubMeetings", "LocationId", "dbo.Locations");
            DropIndex("dbo.BookClubMeetings", new[] { "LocationId" });
        }
    }
}
