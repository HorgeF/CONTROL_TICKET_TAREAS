namespace CONTROL_TICKET_TAREA.Dtos
{
    public class PagedList<T>
    {
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public List<T> Items { get; private set; }

        public PagedList(List<T> items, int totalItems, int currentPage, int pageSize = 10)
        {
            Items = items;
            TotalItems = totalItems;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);
            CurrentPage = currentPage;

            StartPage = Math.Max(1, currentPage - 2);
            EndPage = Math.Min(TotalPages, currentPage + 2);

            int visiblePages = EndPage - StartPage + 1;
            if (visiblePages < 5)
            {
                if (StartPage > 1)
                    StartPage = Math.Max(1, EndPage - 4);
                else if (EndPage < TotalPages)
                    EndPage = Math.Min(TotalPages, StartPage + 4);
            }
        }
    }
}
