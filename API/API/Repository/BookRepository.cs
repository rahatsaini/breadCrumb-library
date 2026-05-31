using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class BookRepository : IBookRepository
    {
        LibraryDbContext _dbContext;
        public BookRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Book> AddAsync(Book book)
        {
            book.CreatedAtUTC = DateTime.UtcNow;
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);
            if (book == null)
            {
                throw new InvalidOperationException("Book not found");
            }
            book.IsActive = false;
            await UpdateAsync(book);
            return true;
        }



        public async Task<IEnumerable<Book>> GetBooksAsync(string? search = null, bool? isAvailable = null)
        {
            var query = _dbContext.Books.AsQueryable();
            query = query.Where(b => b.IsActive);
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(b => b.Title.ToLower().Contains(search.ToLower()));
            }
            if (isAvailable.HasValue && !isAvailable.Value)
            {
                query = query.Where(b => b.IsAvailable);
            }
            return await query.OrderBy(x => x.Title).ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _dbContext.Books.FindAsync(id);
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            var existingBook = await _dbContext.Books.FindAsync(book.Id);
            if (existingBook == null)
            {
                throw new InvalidOperationException("Book not found");
            }
            existingBook = book;
            await _dbContext.SaveChangesAsync();
            return existingBook;
        }
    }
}
