using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RankedChoiceBookClub.Models
{
    public class RankedChoiceBookClubContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RankedChoiceBookClubContext() : base("name=RankedChoiceBookClubContext")
        {
        }

        public System.Data.Entity.DbSet<RankedChoiceBookClub.Models.Book> Books { get; set; }
        public System.Data.Entity.DbSet<RankedChoiceBookClub.Models.Author> Authors { get; set; }
        public System.Data.Entity.DbSet<RankedChoiceBookClub.Models.BookClub> BookClubs { get; set; }
        public System.Data.Entity.DbSet<RankedChoiceBookClub.Models.BookClubMeeting> BookClubMeetings { get; set; }
        public System.Data.Entity.DbSet<RankedChoiceBookClub.Models.BookVote> BookVotes { get; set; }
        public System.Data.Entity.DbSet<RankedChoiceBookClub.Models.Location> Locations { get; set; }
    }
}
