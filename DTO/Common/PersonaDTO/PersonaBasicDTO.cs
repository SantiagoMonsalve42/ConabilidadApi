namespace DTO.Common.PersonaDTO
{
    public class PersonaBasicDTO
    {
        public long Id { get; set; }
        public string Nombre1 { get; set; }
        public string? Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string? Apellido2 { get; set; }
        public long IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string? UrlFoto { get; set; }
        public string Email { get; set; }
    }
}
