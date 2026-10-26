namespace Vonica_Alexandru_Lab2.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; } = default!;
        public IEnumerable<Book> Books { get; set; } = default!;
    }
}