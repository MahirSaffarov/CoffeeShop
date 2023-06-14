namespace CoffeeShop.Models
{
    public class Aroma:BaseEntity
    {
        public string? Name { get; set; }
        public ICollection<ProductAroma>? ProductAromas { get; set; }
    }
}
