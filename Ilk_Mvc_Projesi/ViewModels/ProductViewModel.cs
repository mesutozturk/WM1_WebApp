namespace Ilk_Mvc_Projesi.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? SupplierId { get; set; }
        public string CompanyName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}