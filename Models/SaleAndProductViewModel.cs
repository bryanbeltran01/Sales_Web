namespace Sales_Web.Models
{
    public class SaleAndProductViewModel
    {
        public Sale Sale { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
