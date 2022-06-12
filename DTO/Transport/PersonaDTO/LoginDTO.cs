using System.ComponentModel.DataAnnotations;

namespace DTO.Transport.PersonaDTO
{
    public class LoginDTO
    {
        [EmailAddress]
        public string email { get; set; }
        public string password { get; set; }
    }
}
