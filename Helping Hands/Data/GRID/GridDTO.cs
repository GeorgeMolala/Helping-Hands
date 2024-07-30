namespace Helping_Hands.Data
{
    public class GridDTO
    {

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 8;
        public string SortField { get; set; }
        public string SortDirection { get; set; } = "asc";

    }
}
