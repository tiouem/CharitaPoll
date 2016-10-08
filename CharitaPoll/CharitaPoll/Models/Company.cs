using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharitaPoll.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }


        public List<Survey> Surveys { get; set; }   
    }
}