using Checkout.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.BLL.Interfaces
{
    public interface ICheckoutManager
    {
        void Scan(string sku);
        List<ShopingCart> GetItems();
        ShopingCart GetItem(string sku);
        decimal GetTotalPrice();
    }
}
