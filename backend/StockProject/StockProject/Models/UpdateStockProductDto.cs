namespace StockProject.Models
{
    public class UpdateStockProductDto
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public bool StockIn  { get; set; }
    }
}
