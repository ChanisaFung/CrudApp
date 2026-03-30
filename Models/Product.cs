using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class Product
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public string Category { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        public double Price { get; set; }

        public string Shade { get; set; } // tono (ej: Nude, Rojo)

        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int Quantity { get; set; }

        public string Description { get; set; }
    }
}
