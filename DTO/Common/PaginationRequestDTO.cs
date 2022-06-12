namespace DTO.Common
{
    public class PaginationRequestDTO
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public bool orderByDesc { get; set; }
        public string orderBy { get; set; }
    }
}
