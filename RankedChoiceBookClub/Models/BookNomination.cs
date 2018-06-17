using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RankedChoiceBookClub.Models
{
    public class BookNomination
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public BookClubMeeting BookClubMeeting { get; set; }
    }
}