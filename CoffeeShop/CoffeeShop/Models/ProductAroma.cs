namespace CoffeeShop.Models
{
    public class ProductAroma
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AromaId { get; set; }
        public Aroma? Aroma { get; set; }
        public Product? Product { get; set; }
    }
}
