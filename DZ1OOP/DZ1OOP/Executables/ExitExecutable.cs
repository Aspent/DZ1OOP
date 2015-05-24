using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ1OOP.MenuEngine;

namespace DZ1OOP.Executables
{
    public class ExitExecutable : IExecutable
    {
        public void Execute()
        {
            Environment.Exit(0);           
        }
    }
}
