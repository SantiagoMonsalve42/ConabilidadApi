namespace DTO.Common
{
    public class PaginationDTO<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public string OrderBy { get; set; }
        public bool OrderByDesc { get; set; }
        public ICollection<T> Result { get; set; }
    }
}
