using BaseRestApi.Utility.Interface;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;


namespace BaseRestApi.Utility
{
    public class Trace : ITrace
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public Trace(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetTraceId()
        {
            string errorNumber = Activity.Current?.Id ?? httpContextAccessor.HttpContext.TraceIdentifier;

            return (errorNumber);
        }
    }
}