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

        public Company()
        {
            this.Id = -1;
            this.Name = "";
            this.Sectors = new List<string>();
            this.Addresses = new List<Address>();
            this.Contacts = new List<Contact>();
            this.Comments = new List<Comment>();
        }
    }
}
