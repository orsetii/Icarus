using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veil.Data.Stock;

namespace Veil.Services
{
    public class StockService
    {
        public StockService()
        {

        }

        public List<StockItem> GetStockItems()
        {
            return new List<StockItem>()
            {
                new StockItem() { Name = "Example no. 1" },
            };

        }
    }
}
