using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RankedChoiceBookClub.Models;
namespace RankedChoiceBookClub.ViewModels
{
    public class BookClubMeetingFormVM
    {
        //Use IEnumerable to this to be more loosely coupled
        public IEnumerable<Book> BookOptions { get; set; }
        public IEnumerable<BookClub> BookClubs { get; set; }
        public BookClubMeeting BookClubMeeting { get; set; }

    }
}