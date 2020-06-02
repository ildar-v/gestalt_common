﻿namespace Gestalt.Common.Models
{
    public class MainResponse
    {
        public string count { get; set; }
        public string count_text { get; set; }
        public string max_id { get; set; }

        public ResultFilter filter { get; set; }
        public Queries[] requests { get; set; }
    }

    public class ResultFilter
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