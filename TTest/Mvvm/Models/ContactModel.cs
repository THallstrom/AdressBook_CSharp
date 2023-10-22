namespace TTest.Mvvm.Models
{
    public class ContactModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PostAdress { get; set; } = null!;
        public string PostNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
