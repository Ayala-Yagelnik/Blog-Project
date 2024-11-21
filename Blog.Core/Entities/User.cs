namespace Blog.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }      
        public string Country { get; set; }
        public byte[] Icon { get; set; }
        public string Bio { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
