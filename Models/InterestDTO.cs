using static PeopleInterest.Controllers.PeopleController;

namespace PeopleInterest.Models
{
    public class InterestDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<InterestLinkDTO> Links { get; set; } = [];
    }
}
