using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RankedChoiceBookClub.Models
{
    public class BookClubMeeting
    {
        public int Id { get; set; }
        [Display(Name ="Book Club")]
        public int BookClubId { get; set; }
        public BookClub BookClub { get; set; }
        [Display(Name ="Location")]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public DateTime Date { get; set; }
        [Display(Name="Book")]
        public int BookId { get; set; }
        public IEnumerable<BookNomination> BookNominations { get; set; }
        public IEnumerable<BookVote> BookVotes { get; set; }


        //Search for winner among current BookVotes and break tie using ranked choice
        public Book FindBookVoteWinner()
        {
            // <book id, vote count>
            Dictionary<int, int> VoteTally = new Dictionary<int, int>();
            bool winnerFound = false;
            int choicePosition = 1;
            while (!winnerFound)
            {
                foreach (var vote in BookVotes)
                {
                    
                }
            }
            return new Book();
        }
    }
}
