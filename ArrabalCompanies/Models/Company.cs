namespace ArrabalCompanies.Models
{
    public class Company
    {
        public int Id;
        public string Name;
        public List<string> Sectors;
        public List<Address> Addresses;
        public List<Contact> Contacts;
        public List<Comment> Comments;
        public string Logo;

        public Company()
        {
            this.Id = -1;
            this.Name = "";
            this.Sectors = new List<string>();
            this.Addresses = new List<Address>();
            this.Contacts = new List<Contact>();
            this.Comments = new List<Comment>();
            this.Logo = "";
        }

        public string SelectFirstTelephone()
        {
            foreach(var contact in this.Contacts)
            {
                if(contact.Telephone != "")
                {
                    return contact.Telephone;
                }
            }
            return "";
        }

        public string SelectFirstMail()
        {
            foreach(var contact in this.Contacts)
            {
                if(contact.Mail != "")
                {
                    return contact.Mail;
                }
            }
            return "";
        }

        public string SelectFirstAddress()
        {
            if (this.Addresses.Count == 0)
                return "";
            return (this.Addresses[0].Street + " " + this.Addresses[0].City).Trim();
        }
    }
}
