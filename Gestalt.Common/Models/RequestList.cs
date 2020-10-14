namespace Gestalt.Common.Models
{
    public class RequestList
    {
        public string count { get; set; }

        public string count_text { get; set; }

        public string max_id { get; set; }

        public Filter filter { get; set; }

        public Request[] requests { get; set; }
    }
}