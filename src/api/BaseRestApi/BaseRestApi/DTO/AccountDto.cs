namespace BaseRestApi.DTO
{
    public class AccountDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "Admin";
        public string Jwt { get; set; }
    }
}