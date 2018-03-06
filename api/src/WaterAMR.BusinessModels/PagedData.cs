using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.BusinessModels
{
    public class PagedData<T>
    {
        public int? PageNumber { get; set; }
        public int? NumberOfRecords { get; set; }
        public T Data { get; set; }
        public string SortBy { get; set; }
        public bool SortAsc { get; set; }

    }
}
