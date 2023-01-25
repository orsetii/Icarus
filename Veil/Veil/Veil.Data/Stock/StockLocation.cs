using System.ComponentModel.DataAnnotations;

namespace Veil.Data.Stock
{
    public class StockLocation
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}