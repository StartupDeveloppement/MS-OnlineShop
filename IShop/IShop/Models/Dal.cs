using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShop.Models
{
    class Dal
    {
        private DataBaseIShopEntities bdd;

        public Dal()
        {
            bdd = new DataBaseIShopEntities();
        }
    }
}
