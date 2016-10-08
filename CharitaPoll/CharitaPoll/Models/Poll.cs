using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharitaPoll.Models
{
    public class Poll
    {
        public int PollId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public int PriceRange { get; set; }

        public string Definition { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }

        public int? UserId { get; set; }
        public int CharityId { get; set; }

        public virtual User User { get; set; }
        public virtual Charity Charity { get; set; }

        public virtual List<Answer> Answers { get; set; }
    }
}