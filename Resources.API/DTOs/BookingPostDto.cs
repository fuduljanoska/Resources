using System;
using System.ComponentModel.DataAnnotations;

namespace Resources.API.DTOs
{
    public class BookingPostDto
    {
        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int BookedQuantity { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ResourceId { get; set; }
    }
}
