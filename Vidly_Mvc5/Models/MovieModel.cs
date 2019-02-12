
using System.ComponentModel.DataAnnotations;

namespace Vidly_Mvc5.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}