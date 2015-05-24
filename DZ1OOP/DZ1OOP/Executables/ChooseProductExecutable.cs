using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ1OOP.Domain;
using DZ1OOP.MenuEngine;

namespace DZ1OOP.Executables
{
    class ChooseProductExecutable : IExecutable
    {
        private ProductsRepository _productsRepository;

        public ChooseProductExecutable(ProductsRepository repository)
        {
            _productsRepository = repository;
        }

        public void Execute()
        {
            var number = new int();
            Console.WriteLine("Введите номер изделия");
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Неверный ввод данных");
                Console.WriteLine("Введите номер изделия");
            }
            if (number < 1 || number > _productsRepository.Count)
            {
                Console.WriteLine("Нет изделия с таким номером");
                return;
            }
            var product = _productsRepository.GetByNumber(number);
            
            var workLogRepos = new WorkLogEntriesRepository(product.WorkLogEntries);
            Menu workLogMenu = new Menu();
            if (product.Status == "Дорабатывается" || product.Status == "Изготавливается")
            {
                workLogMenu.AddCommand(new MenuCommand("Добавить новую запись о рабочем времени"
                    , new AddWorkLogEntryExecutable(workLogRepos)));
            }
            workLogMenu.AddCommand(new MenuCommand("Показать все записи"
                , new ShowWorkLogExecutable(workLogRepos)));

            if (product.Status == "Дорабатывается" || product.Status == "Изготавливается")
            {
                workLogMenu.AddCommand(new MenuCommand("Выпустить изделие"
                , new CompleteProductExecutable(workLogMenu, product)));
                workLogMenu.AddCommand(new MenuCommand("Доработать изделие"
                , new RefineProductExecutable(workLogMenu, product)));
                workLogMenu.AddCommand(new MenuCommand("Утилизировать изделие"
                , new UtilizeProductExecutable(workLogMenu, product)));
            }
            else
            {
                workLogMenu.AddCommand(new MenuCommand("Продолжить"
                    , new CloseMenuExecutable(workLogMenu)));
            }
            workLogMenu.Run();
            if(product.Status == "Утилизация")
            {
                _productsRepository.RemoveProduct(product);
            }
        }
    }
}
