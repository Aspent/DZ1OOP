using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ1OOP.Domain;
using DZ1OOP.MenuEngine;

namespace DZ1OOP.Executables 
{
    class ChooseBatchExecutable : IExecutable
    {
        private readonly BatchesRepository _batchesRepository;

        public ChooseBatchExecutable(BatchesRepository repository)
        {
            _batchesRepository = repository;
        }

        public void Execute()
        {
            var number = new int();
            Console.WriteLine("Введите номер партии");
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Неверный ввод данных");
                Console.WriteLine("Введите номер партии");
            }
            if (number < 1 || number > _batchesRepository.Count)
            {
                Console.WriteLine("Нет партии с таким номером");
                return;
            }
            var batch = _batchesRepository.GetByNumber(number);

            var productsRepos = new ProductsRepository(batch.Products);
            Menu productMenu = new Menu();

            productMenu.AddCommand(new MenuCommand("Добавить новое изделие"
                , new AddProductExecutable(productsRepos)));
            productMenu.AddCommand(new MenuCommand("Выбрать изделие по номеру"
                , new ChooseProductExecutable(productsRepos)));
            productMenu.AddCommand(new MenuCommand("Показать все изделия"
                , new ShowProductsExecutable(productsRepos)));
            productMenu.AddCommand(new MenuCommand("Продолжить"
                , new CloseMenuExecutable(productMenu)));
            productMenu.Run();
        }
    }
}
