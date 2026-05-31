using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Book
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(100)]
        public string? Author { get; set; }

        public bool IsAvailable { get; set; }
        public bool IsActive { get; set; }

        [MaxLength(100)]
        public string? Owner { get; set; }

        [MaxLength(100)]
        public string? BorrowedBy { get; set; }

        public DateTime? BorrowedAtUTC { get; set; }

        public DateTime CreatedAtUTC { get; set; } = DateTime.UtcNow;



    }
}
