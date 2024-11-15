using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pacifica.API.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required] 
        [StringLength(255)]  
        public string ProductName { get; set; } = string.Empty;

        [Required] 
        [StringLength(50)]  // Limits the length of the SKU
        public string SKU { get; set; } = string.Empty;

        [Required] 
        public DateTime DateAdded { get; set; }

        // Date when the product was last updated
        public DateTime LastUpdated { get; set; }

        // Reorder level for the product (stock threshold for reordering)
        [Required]  // Ensures ReorderLevel is provided
        public int ReorderLevel { get; set; }

        // Minimum stock level for the product
        [Required]  // Ensures MinStockLevel is provided
        public int MinStockLevel { get; set; }

        // Status of the product (e.g., Available, Discontinued, Out of Stock)
        [Required]  // Ensures ProductStatus is provided
        [StringLength(50)]  // Limits the length of ProductStatus
        public string ProductStatus { get; set; } = "Available";

        // Foreign Key: Relates the product to its category
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        // Foreign Key: Relates the product to its supplier
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        // Navigation property for related stock transactions (inventory movements)
        public ICollection<StockTransactionInOut>? StockTransactionInOuts { get; set; }

        // Navigation property for related branch products (branch-specific prices and stock)
        public ICollection<BranchProduct>? BranchProducts { get; set; }
        

        // Audit fields to track creation, update, and soft delete
        [Required]  // Ensures CreatedAt is provided
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Date when the product record was last updated
        public DateTime? UpdatedAt { get; set; }

        // Soft delete: Marks the product as deleted (if null, the product is active)
        public DateTime? DeletedAt { get; set; }

        // Tracks who created the product record
        [StringLength(100)]  // Limits CreatedBy field length
        public string? CreatedBy { get; set; }

        // Indicates if the product is active in the system
        [Required]  // Ensures IsActive is provided
        public bool IsActive { get; set; } = true;

        // Tracks who last updated the product record
        [StringLength(100)]  // Limits UpdatedBy field length
        public string? UpdatedBy { get; set; }
    }
}
