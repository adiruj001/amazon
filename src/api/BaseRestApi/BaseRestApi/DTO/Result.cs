using BaseRestApi.Utility.Interface;


namespace BaseRestApi.DTO
{
    public class Result<T>
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public string TraceId { get; }
        public T Data { get; set; }  

        public Result(ITrace trace)
        {
            TraceId = trace.GetTraceId();
        }

        public string GetLog()
        {
            string message = string.Empty;

            message += $"Success: [{Success}]";
            message += $"Message: [{Message}]";
            message += $"TraceId: [{TraceId}]";
            message += $"Data: [{Data}]";

            return (message);
        }

        public string GetLogWithNoData()
        {
            string message = string.Empty;

            message += $"Success: [{Success}]";
            message += $"Message: [{Message}]";
            message += $"TraceId: [{TraceId}]";            

            return (message);
        }
    }
}