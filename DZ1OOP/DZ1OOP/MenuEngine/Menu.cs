using System;
using System.Collections.Generic;

namespace DZ1OOP.MenuEngine
{
    class Menu
    {
        List<MenuCommand> _commands = new List<MenuCommand>();
        bool _isExit = false;
        
        public void AddCommand(MenuCommand command)
        {
            _commands.Add(command);
        }

        public void PrintCommands()
        {
            int number = 1;
            foreach(var t in _commands)
            {
                Console.WriteLine("{0} - {1}", number, t.Title);
                number++;
            }
        }

        public void Close()
        {
            _isExit = true;
        }

        public int ReadCommand()
        {
            Console.WriteLine("Введите номер команды: ");
            var number = new int();
            while(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Неверный ввод данных");
                Console.WriteLine("Введите номер команды: ");
            }
            Console.WriteLine();
            return number;
            
        }

        public void ExecuteCommand(int number)
        {
            _commands[number - 1].Execute();

        }

        public void Run()
        {
            Console.Clear();
            while(!_isExit)
            {
                PrintCommands();
                var number = ReadCommand();
                if (number < 1 || number > _commands.Count)
                {
                    Console.WriteLine("Команды с таким номером не существует");
                    Console.WriteLine();
                }
                else
                {
                    ExecuteCommand(number);
                }
            }
        }
    }
}
