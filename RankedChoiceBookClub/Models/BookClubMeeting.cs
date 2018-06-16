using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankedChoiceBookClub.Models
{
    public class BookClubMeeting
    {
        public int Id { get; set; }
        public BookClub BookClub { get; set; }
        public Location Location { get; set; }
        public DateTime Date { get; set; }
        public Book Book { get; set; }
        public List<BookVote> BookVotes { get; set; }


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
