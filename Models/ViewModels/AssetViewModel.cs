using System.ComponentModel.DataAnnotations;

namespace AssetIQ.Models.ViewModels
{
    public class AssetViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Purchase date is required")]
        [DataType(DataType.Date)]
        public DateTime? PurchaseDate { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, 10000000, ErrorMessage = "Price must be greater than 0")]
        public decimal? Price { get; set; }

        public bool IsAssigned { get; set; }
    }
}