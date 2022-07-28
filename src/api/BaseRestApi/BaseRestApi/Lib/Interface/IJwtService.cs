using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseRestApi.Lib.Interface
{
    public interface IJwtService
    {
        string GenerateJwtTokenString(string uniqueName, string role);
        string DecodeJwtAndGetClaimValue(HttpRequest httpRequest, string key = "unique_name");
    }
}