﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankedChoiceBookClub.Models
{
    public class Book
    {
        public int Id { get; set; }
        public Author Author { get; set;  }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
    }
}
