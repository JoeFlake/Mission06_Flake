using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Flake.Models
{
    public class MovieViewModel
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Sorry, you need to enter a title")]
        public string Title { get; set; }

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Sorry, you need to enter a year no earlier than 1888")]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [Required]
        public bool CopiedToPlex { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; }
    }

}
