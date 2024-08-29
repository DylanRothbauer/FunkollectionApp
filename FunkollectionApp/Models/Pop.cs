using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunkollectionApp.Models
{
    public class Pop
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Category { get; set; }

        // image
        public byte[]? ImageData { get; set; }

        
        public string UserId { get; set; }
    }
}
