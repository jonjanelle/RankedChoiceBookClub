using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankedChoiceBookClub.Models
{
    public class BookVote
    {
        public int Id { get; set; }
        public BookClubMeeting BookClubMeeting { get; set; }
        public Book Choice1 { get; set; }
        public Book Choice2 { get; set; }
        public Book Choice3 { get; set; }
    }
}
