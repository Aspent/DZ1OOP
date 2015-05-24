using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1OOP.Domain
{
    interface IDescriptionSource
    {
        List<ProductDescription> GetListOfDescriptions();
    }
}
