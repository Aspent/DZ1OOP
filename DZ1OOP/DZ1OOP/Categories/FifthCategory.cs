using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ1OOP.Domain;

namespace DZ1OOP.Categories
{
    class FifthCategory : ICategory
    {
        public bool Belongs(Batch batch)
        {
            return true;
        }
    }
}
