using BaseRestApi.DTO;
using BaseRestApi.Lib.Interface;
using BaseRestApi.Services.Interface;
using BaseRestApi.Utility;
using BaseRestApi.Utility.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BaseRestApi.Services
{
    public class AccountService : IAccountService
    {
        private AppSettings AppSettings { get; }
        private ITrace Trace { get; }
        private IJwtService JwtService { get; }

        private ILogger<AccountService> Logger { get; }

        public AccountService(IJwtService JwtService, IOptions<AppSettings> AppSettings, ITrace Trace, ILogger<AccountService> Logger)
        {
            this.JwtService = JwtService;
            this.AppSettings = AppSettings.Value;
            this.Trace = Trace;
            this.Logger = Logger;
        }
        public Result<AccountDto> LoginAccount(AccountDto account)
        {
            Result<AccountDto> result = new Result<AccountDto>(Trace);
            if(account.Username.Equals("admin") && account.Password.Equals("1234"))
                {
                var role = account.Role == Constant.Role.Admin ? Constant.Role.Admin : Constant.Role.User;
                    result.Success = true;
                    result.Message = AppSettings.SuccessMessage.LoginSuccess;
                result.Data = new AccountDto
                {
                    Username = account.Username,
                    Role = role,
                        Jwt = JwtService.GenerateJwtTokenString(account.Username, role) 
                    };
                }
                else
                {
                    result.Message = AppSettings.ErrorMessage.LoginFailed;
                }
            
            return result;
        }
    }
}