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
    }
}
