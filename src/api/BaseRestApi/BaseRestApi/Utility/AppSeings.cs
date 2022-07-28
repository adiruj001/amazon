namespace BaseRestApi.Utility
{
    public class AppSettings
    {              
        public Smtp Smtp { get; set; }       
        public Jwt Jwt { get; set; }
        public ErrorMessage ErrorMessage { get; set; }
        public SuccessMessage SuccessMessage { get; set; }
    }
    
    public class Smtp
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public bool RequireAuthentication { get; set; }
        public bool EnableSsl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }    

    public class Jwt
    {
        public string Secret { get; set; }
        public int ExpireInSec { get; set; }
    }

    public class ErrorMessage
    {
        public string General { get; set; }
        public string EmptyUsername { get; set; }
        public string EmptyPassword { get; set; }
        public string GetFailed { get; set; }
        public string LoginFailed { get; set; }
        public string EmptyProductName { get; set; }
        public string EmptyCategoryId { get; set; }
        public string EmptyProductId { get; set; }
    }
    public class SuccessMessage
    {
        public string CreateSuccess { get; set; }
        public string GetSuccess { get; set; }
        public string ModifySuccess { get; set; }
        public string DeleteSuccess { get; set; }
        public string LoginSuccess { get; set; }
    }
}