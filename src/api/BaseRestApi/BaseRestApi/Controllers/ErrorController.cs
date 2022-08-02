using BaseRestApi.Utility;
using BaseRestApi.Utility.Interface;
using BaseRestApi.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Net;

namespace CRPasswordResetServer.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ITrace trace;
        private readonly AppSettings appSettings;

        public ErrorController(ITrace trace, IOptions<AppSettings> appSettingsAccessor)
        {
            this.trace = trace;
            this.appSettings = appSettingsAccessor.Value;
        }

        [Route("/error")]
        public Result<Object> Error()
        {
            Result<Object> result = new Result<Object>(trace)
            {
                Success = false,
                Message = appSettings.ErrorMessage.General
            };

            //Change HTTP status to OK. Since I wrote code so that agent doesn't expect any data when it's 500. This way agent can parse the data and display error message to users. Error number (traceId) will be logged on both server and agent.
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;

            //return (Problem());
            return (result);
        }
    }
}