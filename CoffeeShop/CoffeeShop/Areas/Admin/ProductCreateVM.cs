using CoffeeShop.Models;

namespace CoffeeShop.Areas.Admin
{
    public class ProductCreateVM
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public List<Aroma> Aromas { get; set; }
    }
}
