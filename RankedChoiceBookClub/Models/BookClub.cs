using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Attributes;

namespace RankedChoiceBookClub.Models
{
    [Validator(typeof(BookClubValidator))]
    public class BookClub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccessCode { get; set; }
        public string Description { get; set; }
        public List<BookClubMeeting> Meetings { get; set; }
    }

    public class BookClubValidator : AbstractValidator<BookClub>
    {
        public BookClubValidator()
        {
            RuleFor(x => x.AccessCode).Must(BeUniqueCode).WithMessage("Access Code already exists");
        }

        private bool BeUniqueCode(string accessCode)
        {
            return new RankedChoiceBookClubContext().BookClubs.FirstOrDefault(x => x.AccessCode == accessCode) == null;
        }
    }

}
