namespace Vonica_Alexandru_Lab2.Models
{
    public class BookData
    {
        public IEnumerable<Book> Books { get; set; } = default!;
        public IEnumerable<Category> Categories { get; set; } = default!;
        public IEnumerable<BookCategory> BookCategories { get; set; } = default!;
    }
}