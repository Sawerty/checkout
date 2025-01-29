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

        private List<SpecialPrice> specialPriceMasters;

        public GenerateTestItems()
        {
            itemMasters=new List<ItemMaster>();
            itemMasters.Add(new ItemMaster { SKU = "A", UnitPrice = 50 });
            itemMasters.Add(new ItemMaster { SKU = "B", UnitPrice = 30 });
            itemMasters.Add(new ItemMaster { SKU = "C", UnitPrice = 20 });
            itemMasters.Add(new ItemMaster { SKU = "D", UnitPrice = 15 });


            specialPriceMasters = new List<SpecialPrice>();
            specialPriceMasters.Add(new SpecialPrice { SKU = "A", Quantity = 3, Price = 130 });
            specialPriceMasters.Add(new SpecialPrice { SKU = "B", Quantity = 2, Price = 45 });
        }


        public List<ItemMaster> GetItemMaster()
        {
            return itemMasters;
        }

        public List<SpecialPrice> GetSpecialPrices()
        {
            return specialPriceMasters;
        }
    }
}
