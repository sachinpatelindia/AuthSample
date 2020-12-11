namespace AuthSample.Model
{
    public class UserModel
    {
        public int UserId { get; set; }
        public bool IsBlocked { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SaltKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
