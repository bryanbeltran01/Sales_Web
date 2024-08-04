namespace Sales_Web.Models
{
    public class SalesProduct
    {
        public int Id { get; set; }
        public int SalesId { get; set; }
        public int ProductsId { get; set; }

        public Sale Sale { get; set; }
        public Product Product { get; set; }
    }

}
