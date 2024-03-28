using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responses
{
    public partial class ApiListResponse<T> : ApiResponse<T>
    {
        public int TotalRecords { get; set; } //1000
        public int TotalRecordsAfterFilter { get; set; } //900
        public int RecordsInOneSlot { get; set; } //50
        public int PageSize { get; set; } //900/50=18    
    }
}
