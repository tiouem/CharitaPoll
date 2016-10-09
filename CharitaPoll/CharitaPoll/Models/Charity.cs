using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharitaPoll.Models
{
    public class Charity
    {
        public int CharityId { get; set; }
        public string Name { get; set; }

        public virtual List<Survey> Surveys { get; set; }
        public virtual List<Poll> Polls { get; set; }
    }
}