using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1OOP.MenuEngine
{
    class MenuCommand
    {
        private readonly string _title;
        private readonly IExecutable _executable;

        public MenuCommand(string title, IExecutable executable)
        {
            _title = title;
            _executable = executable;
        }

        public string Title
        {
            get
            {
                return _title;
            }
        }

        public void Execute()
        {
            _executable.Execute();
        }

    }
}
