using API.Entities;
using API.Repository;

namespace API.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<PagedResult<Book>> GetBooksAsync(
            string? search = null,
            bool? isAvailable = null,
            int page = 1,
            int pageSize = 10)
        {
            var books = await _bookRepository.GetBooksAsync(search, isAvailable);

            var totalCount = books.Count();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var paginatedBooks = books
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<Book>
            {
                Data = paginatedBooks,
                TotalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize
            };
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            book.Id = 0;
            book.CreatedAtUTC = DateTime.UtcNow;
            book.IsAvailable = true;
            book.BorrowedBy = null;
            book.BorrowedAtUTC = null;
            book.IsActive = true;
            return await _bookRepository.AddAsync(book);
        }

        public async Task<Book> ToggleAvailabiltyBookAsync(int id)
        {

            var existing = await _bookRepository.GetByIdAsync(id);
            if (existing != null)
            {

                existing.IsAvailable = !existing.IsAvailable;
                if (!existing.IsAvailable)
                {
                    existing.BorrowedBy = "New user";
                    existing.BorrowedAtUTC = DateTime.UtcNow;
                }
                else
                {
                    existing.BorrowedBy = null;
                    existing.BorrowedAtUTC = null;
                }
                return await _bookRepository.UpdateAsync(existing);

            }

            throw new KeyNotFoundException(
                $"Book with id {id} not found");
        }

        public async Task DeleteBookAsync(int id)
        {
            var existing = await _bookRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException(
                    $"Book with id {id} not found");

            await _bookRepository.DeleteAsync(existing.Id);
        }
    }
}