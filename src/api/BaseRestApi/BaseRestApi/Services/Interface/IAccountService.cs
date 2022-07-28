using BaseRestApi.DTO;

namespace BaseRestApi.Services.Interface
{
    public interface IAccountService
    {
        Result<AccountDto> LoginAccount(AccountDto account);
    }
}