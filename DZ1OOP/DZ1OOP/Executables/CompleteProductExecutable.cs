using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ1OOP.Domain;
using DZ1OOP.MenuEngine;

namespace DZ1OOP.Executables
{
    class CompleteProductExecutable : IExecutable
    {
        private Product _product;
        private Menu _menu;

        public CompleteProductExecutable(Menu menu, Product product)
        {
            _product = product;
            _menu = menu;
        }

        public void Execute()
        {            
            _product.Status = "Выпущено";
            _product.IsDefective = false;
            new CloseMenuExecutable(_menu).Execute();
        }
    }
}
