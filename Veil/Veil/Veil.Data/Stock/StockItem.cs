using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veil.Data.Stock
{
    public class StockItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public StockLocation StockLocation { get; set; }
    }
}
