using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ1OOP.MenuEngine;
using DZ1OOP.Domain;

namespace DZ1OOP.Executables
{
    class UtilizeProductExecutable : IExecutable
    {
        private Product _product;
        private Menu _menu;

        public UtilizeProductExecutable(Menu menu, Product product)
        {
            _product = product;
            _menu = menu;
        }

        public void Execute()
        {
            _product.Status = "Утилизация";
            _product.IsDefective = true;
            new CloseMenuExecutable(_menu).Execute();
        }
    }
}
