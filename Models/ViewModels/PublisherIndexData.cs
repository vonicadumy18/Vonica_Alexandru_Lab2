using Vonica_Alexandru_Lab2.Models;

namespace Vonica_Alexandru_Lab2.Models.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; } = default!;
        public IEnumerable<Book> Books { get; set; } = default!;
    }
}