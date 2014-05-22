using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF5Repository.Service.DataObjects
{
    public class PaginationDataObject<TDataObject> 
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<TDataObject> DataObjects { get; set; }
    }
}
