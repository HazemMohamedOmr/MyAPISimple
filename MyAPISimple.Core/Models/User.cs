namespace MyAPISimple.Core.Models
{
    public class User : BaseEntity<int>
    {
        // These are the fileds that represents the domain model (fields relevant to business logic)

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}