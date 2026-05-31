using API.Entities;

namespace API.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync(
            string? search = null, bool? isAvailable = null);
        Task<Book?> GetByIdAsync(int id);
        Task<Book> AddAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task<bool> DeleteAsync(int id);
    }
}
