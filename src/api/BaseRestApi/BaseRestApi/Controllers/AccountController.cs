using BaseRestApi.DTO;
using BaseRestApi.Services.Interface;
using BaseRestApi.Utility;
using BaseRestApi.Utility.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace BaseRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService AccountService { get; }
        private ILogger<AccountController> Logger { get; }
        private AppSettings AppSettings { get; }
        private ITrace Trace { get; }

        public AccountController(IAccountService AccountService, ILogger<AccountController> Logger, IOptions<AppSettings> AppSettings, ITrace Trace)
        {
            this.AccountService = AccountService;
            this.Logger = Logger;
            this.AppSettings = AppSettings.Value;
            this.Trace = Trace;
        }

        [HttpPost]
        public Result<AccountDto> LoginAccount([FromBody] AccountDto account)
        {
            Result<AccountDto> result = new Result<AccountDto>(Trace);
            if (String.IsNullOrEmpty(account.Username))
            {
                result.Message = AppSettings.ErrorMessage.EmptyUsername;
            }else if (String.IsNullOrEmpty(account.Password))
            {
                result.Message = AppSettings.ErrorMessage.EmptyPassword;
            }
            else
            {
                result = AccountService.LoginAccount(account);
            }
            return result;
        }
    }
}