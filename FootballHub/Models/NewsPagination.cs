namespace FootballHub.Models
{
    public class NewsPagination
    {
        public List<News> NewsList { get; set; }
        public int PageNumber { get; set; }
        public int CurrentPage { get; set; }
        public int PreviousPage
        {
            get
            {
                return CurrentPage - 1;
            }
        }
        public int NextPage
        {
            get
            {
                return CurrentPage + 1;
            }
        }
        public bool PreviousPageAvailable
        {
            get
            {
                return CurrentPage != 1;
            }
        }
        public decimal LastPage { get; set; }
    }
}
