using System;

namespace PeopleInterest.Models
{
    public class InterestLink
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int InterestId { get; set; }
        public Interest Interest { get; set; }
    }
}
