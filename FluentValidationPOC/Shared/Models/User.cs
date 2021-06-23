namespace FluentValidationPOC.Shared.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; } // This does not belong in a domain class but it's a demo :)
        public Address Address { get; set; } = new Address();

    }

    public class Address
    {
        public string Street { get; set; }
        public string Postcode { get; set; }
        public string Town { get; set; }
        public Country Country { get; set; }
    }

    public enum Country
    {
        Sweden,
        Norway
    }
}
