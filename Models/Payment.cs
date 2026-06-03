namespace WebApplication1.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
