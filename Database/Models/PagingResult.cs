using System.Collections.Generic;

namespace SC.VersionManagement.Models
{
    public class PagingResult<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Total { get; set; }
        public IEnumerable<T> Result { get; set; }

        public PagingResult(int pageIndex, int pageSize, long total, IEnumerable<T> result) : this(pageIndex, pageSize)
        {
            Total = total;
            Result = result;
        }

        public PagingResult(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Total = 0;
            Result = null;
        }

        public PagingResult()
        {

        }
    }
}
