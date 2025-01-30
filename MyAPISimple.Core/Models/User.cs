namespace MyAPISimple.Core.Models
{
    public class User
    {
        // These are the fileds that represents the domain model (fields relevant to business logic)

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}