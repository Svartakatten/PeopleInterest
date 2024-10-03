using static PeopleInterest.Controllers.PeopleController;

namespace PeopleInterest.Models
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<InterestDTO> Interests { get; set; } = [];
    }
}
