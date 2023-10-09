namespace ArrabalCompanies.Models
{
    public class Address
    {
        public string Street;
        public int PostalCode;
        public string City;
        public string Country;

        public Address()
        {
            this.Street = "";
            this.PostalCode = 0;
            this.City = "";
            this.Country = "";
        }
    }
}
