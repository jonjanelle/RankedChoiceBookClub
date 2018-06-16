using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankedChoiceBookClub.Models
{
    public class BookClub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccessCode { get; set; }
        public string Description { get; set; }
        public List<BookClubMeeting> Meetings { get; set; }
    }

    
}
