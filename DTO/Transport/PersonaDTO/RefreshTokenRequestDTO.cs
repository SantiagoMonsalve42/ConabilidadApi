namespace DTO.Transport.PersonaDTO
{
    public class RefreshTokenRequestDTO
    {
        public string TokenSesion { get; set; } = null!;
        public string Token512 { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
