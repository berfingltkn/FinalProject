using Core;

namespace Entities.DTOs
{
    //sisteme sign in olmak isteyen bşr kişinin entities i
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
