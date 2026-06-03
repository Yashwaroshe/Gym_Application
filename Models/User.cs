namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }     // 👈 MUST
        public string Email { get; set; }    // 👈 MUST
        public string Password { get; set; }   // Admin / User
    }
}
