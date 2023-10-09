namespace ArrabalCompanies.Models
{
    public class Contact
    {
        public string Firstname;
        public string Lastname;
        public int Telephone;
        public string Mail;

        public Contact()
        {
            this.Firstname = "";
            this.Lastname = "";
            this.Telephone = 0;
            this.Mail = "";
        }
    }
}
