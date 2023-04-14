namespace CityInfo.Api.Services
{
    public class PaginationMetadata
    {
        public int TotalItemCount { get; set; }
        public int TotalPageCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public PaginationMetadata(int totalItemCount, int pageSize, int currentPage)
        {
            TotalItemCount = totalItemCount;
            TotalPageCount = pageSize;
            PageSize = currentPage;
            CurrentPage = (int)Math.Ceiling(totalItemCount / (double)pageSize);
        }
    }
}