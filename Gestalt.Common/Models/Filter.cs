namespace Gestalt.Common.Models
{
    public class Filter
    {
        public string sorting_filter { get; set; }
        public string categories_filter { get; set; }
        public string statuses_filter { get; set; }
        public string area_filter { get; set; }
        public string page_size { get; set; }
        public string page_num { get; set; }
        public string period_filter { get; set; }
        public string search_text { get; set; }
    }
}