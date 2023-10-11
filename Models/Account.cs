namespace Models
{
    public class Account : Entity<int>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
