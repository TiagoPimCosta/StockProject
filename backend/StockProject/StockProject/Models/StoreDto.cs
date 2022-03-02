using System;

namespace StockProject.Models
{
    public class StoreDto
    {
        public Guid Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Activity { get; set; }
        public string Telephone { get; set; }
        public int Nif { get; set; }
    }
}
