using API.Entities;

namespace API.Services
{
    public interface IBookService
    {
        Task<PagedResult<Book>> GetBooksAsync(
              string? search = null,
              bool? isAvailable = null,
              int page = 1,
              int pageSize = 10);
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book> CreateBookAsync(Book book);
        Task<Book> ToggleAvailabiltyBookAsync(int id);
        Task DeleteBookAsync(int id);
    }
}
