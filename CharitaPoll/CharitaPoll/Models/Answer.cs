using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharitaPoll.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string ChoosedAnswer { get; set; }

        public int PollId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Poll Poll { get; set; }


    }
}