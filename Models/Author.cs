namespace Vonica_Alexandru_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string FullName => LastName + " " + FirstName;

        public ICollection<Book>? Books { get; set; }
    }
}