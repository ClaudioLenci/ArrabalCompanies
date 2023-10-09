namespace ArrabalCompanies.Models
{
    public class Comment
    {
        public string Text;
        public string Author;
        public DateTime Date;

        public Comment()
        {
            this.Text = "";
            this.Author = "";
            this.Date = new DateTime();
        }
    }
}
