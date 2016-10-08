using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharitaPoll.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? DateCreated { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Country { get; set; }

        public List<Answer> Answers { get; set; }
    }
}