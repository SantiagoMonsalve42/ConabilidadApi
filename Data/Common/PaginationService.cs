using DTO.Common;
using System.Data.Entity;
using System.Reflection;

namespace Data.Common
{
    public static class PaginationService
    {

        public static async Task<PaginationDTO<T>> GetPagination<T>(IQueryable<T> query, int page, string orderBy, bool orderByDesc, int pageSize) where T : class
        {
            PaginationDTO<T> pagination = new PaginationDTO<T>
            {
                TotalItems = query.Count(),
                TotalPages = (query.Count() + pageSize - 1) / pageSize,
                PageSize = pageSize,
                CurrentPage = page,
                OrderBy = orderBy,
                OrderByDesc = orderByDesc
            };

            int skip = (page - 1) * pageSize;
            var props = typeof(T).GetProperties();
            var orderByProperty = props.FirstOrDefault(n => n.GetCustomAttribute<SortableAttribute>()?.OrderBy == orderBy);


            if (orderByProperty == null)
            {
                throw new Exception($"Field: '{orderBy}' is not sortable");
            }

            if (orderByDesc)
            {
                pagination.Result = query
                    .OrderByDescending(x => orderByProperty.GetValue(x))
                    .Skip(skip)
                    .Take(pageSize)
                    .ToList();

                return pagination;
            }
            pagination.Result = query
                .OrderBy(x => orderByProperty.GetValue(x))
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            return pagination;
        }
    }
}
