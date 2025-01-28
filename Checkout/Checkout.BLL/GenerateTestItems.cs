using Checkout.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.BLL
{
    public class GenerateTestItems
    {
        private List<ItemMaster> itemMasters;

        public GenerateTestItems()
        {
            itemMasters=new List<ItemMaster>();
            itemMasters.Add(new ItemMaster { SKU = "A", UnitPrice = 50 });
            itemMasters.Add(new ItemMaster { SKU = "B", UnitPrice = 30 });
            itemMasters.Add(new ItemMaster { SKU = "C", UnitPrice = 20 });
            itemMasters.Add(new ItemMaster { SKU = "D", UnitPrice = 15 });

        }


        public List<ItemMaster> GetItemMaster()
        {
            return itemMasters;
        }
    }
}
