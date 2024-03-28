namespace Utility
{
    internal class ApiListResponse<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<T> Data { get; set; }
        public int StatusCode { get; set; }
        public int TotalRecords { get; set; }
        public int TotalRecordsAfterFilter { get; set; }
        public int RecordsInOneSlot { get; set; }
        public int PageSize { get; set; }
    }
}