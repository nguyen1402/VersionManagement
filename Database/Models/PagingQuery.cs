using System.ComponentModel.DataAnnotations;

namespace SC.VersionManagement.Models
{
    public class PagingQuery
    {

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string FieldName { get; set; }
        public bool OrderByDesc { get; set; }
        public PagingQuery()
        {
            PageIndex = 1;
            PageSize = 10;
            FieldName = string.Empty;
            OrderByDesc = false;
        }
    }
}
