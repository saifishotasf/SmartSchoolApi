using System;
using System.Collections.Generic;
using System.Linq;
using Utility.GlobalErrorHandling;

namespace Utility
{
    public static class CommonResponses
    {
        public partial class ApiListResponse<T> : ApiResponse<T>
        {
            public int TotalRecords { get; set; } // 1000
            public int TotalRecordsAfterFilter { get; set; } // 900
            public int RecordsInOneSlot { get; set; } // 50
            public int PageSize { get; set; } // 900/50=18    
            public ErrorDetails Error { get; set; }
        }

        public static ApiListResponse<IEnumerable<T>> GetPaginatedApiResponse<T>(
            this IEnumerable<T> items, int totalRecords, int currentPage, int pageSize)
        {
            var paginatedItems = items.Skip((currentPage - 1) * pageSize).Take(pageSize);

            if (paginatedItems.Any())
            {
                return new ApiListResponse<IEnumerable<T>>
                {
                    Message = string.Format(Messages.Success),
                    IsSuccess = true,
                    Data = paginatedItems,
                    StatusCode = 200,
                    TotalRecords = totalRecords,
                    TotalRecordsAfterFilter = items.Count(),
                    RecordsInOneSlot = pageSize,
                    PageSize = (int)Math.Ceiling((double)totalRecords / pageSize)
                };
            }
            else
            {
                return new ApiListResponse<IEnumerable<T>>
                {
                    Message = string.Format(Messages.NoRecordFound),
                    IsSuccess = true,
                    Data = paginatedItems,
                    StatusCode = 404,
                    TotalRecords = 0,
                    TotalRecordsAfterFilter = 0,
                    RecordsInOneSlot = 0,
                    PageSize = 0
                };
            }
        }

        public static ApiListResponse<IEnumerable<T>> CacheExceptionListResponse<T>(Exception ex)
        {
            return new ApiListResponse<IEnumerable<T>>
            {
                Message = string.Format(Messages.InternalServerError),
                IsSuccess = false,
                Data = null,
                StatusCode = 500,
                TotalRecords = 0,
                TotalRecordsAfterFilter = 0,
                RecordsInOneSlot = 0,
                PageSize = 0,
                Error = new ErrorDetails
                {
                    StatusCode = 500,
                    Message = ex.Message
                }
            };
        }

        public static int CalculatePageSize(int totalRecords, int customPageSize)
        {
            return totalRecords > 0 ? Math.Min(customPageSize, totalRecords) : 1;
        }
    }
}
