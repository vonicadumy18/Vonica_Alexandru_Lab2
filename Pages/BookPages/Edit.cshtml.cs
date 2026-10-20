using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vonica_Alexandru_Lab2.Data;
using Vonica_Alexandru_Lab2.Models;

namespace Vonica_Alexandru_Lab2.Pages.BookPages
{
    public class EditModel : BookCategoriesPageModel
    {
        private readonly Vonica_Alexandru_Lab2Context _context;

        public EditModel(Vonica_Alexandru_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            Book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Book is null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Book);

            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id is null)
            {
                return NotFound();
            }

            var bookToUpdate = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)
                    .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (bookToUpdate is null)
            {
                return NotFound();
            }

            bookToUpdate.Title = Book.Title;
            bookToUpdate.AuthorID = Book.AuthorID;
            bookToUpdate.Price = Book.Price;
            bookToUpdate.PublishingDate = Book.PublishingDate;
            bookToUpdate.PublisherID = Book.PublisherID;

            if (!ModelState.IsValid)
            {
                PopulateAssignedCategoryData(_context, bookToUpdate);
                ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "FullName", bookToUpdate.AuthorID);
                ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName", bookToUpdate.PublisherID);
                return Page();
            }

            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.ID == id);
        }
    }
}