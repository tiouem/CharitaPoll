using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharitaPoll.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public string Name { get; set; }


        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual List<Poll> Polls { get; set; }
    }
}