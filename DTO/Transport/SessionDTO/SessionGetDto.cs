namespace DTO.Transport.SessionDTO
{
    public class SessionGetDto
    {
        public long IdPersona { get; set; }
        public string TokenSesion { get; set; } = null!;
        public string Token512 { get; set; } = null!;
        public DateTime Hora { get; set; }
        public long IdSesion { get; set; }
    }
}
