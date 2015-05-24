using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DZ1OOP.Domain;
using DZ1OOP.MenuEngine;
using System.IO;

namespace DZ1OOP.Executables
{
    class AddProductExecutable : IExecutable
    {
        private readonly ProductsRepository _productsRepository;

        public AddProductExecutable(ProductsRepository repository)
        {
            _productsRepository = repository;
        }

        public void Execute()
        {
            Console.WriteLine("Введите серийный номер изделия");
            var serialNumber = Console.ReadLine();
            while (serialNumber == "")
            {
                Console.WriteLine("Не введен серийный номер изделия.");
                Console.WriteLine("Введите серийный номер изделия");
                serialNumber = Console.ReadLine();
            }

            var releaseDateTime = new DateTime();
            Console.WriteLine("Введите время изготовления изделия");
            while (!DateTime.TryParse(Console.ReadLine(), out releaseDateTime)) 
            {
                Console.WriteLine("Введены неверные данные");
                Console.WriteLine("Введите время изготовления изделия");
            }        
            var isDefective = false;

            //IDescriptionSource descriptionsRepository = new ProductDescriptionsRepository();
            //IDescriptionSource descriptionsRepository = new DatFileDescriptionsSource("products.dat");
            try
            {
                IDescriptionSource descriptionsRepository = new TxtFileDescriptionsSource("catalog.txt");
                var descriptions = descriptionsRepository.GetListOfDescriptions();
                var descriptionPrinter = new DescriptionPrinter(descriptions);
                descriptionPrinter.PrintAll();
                var number = new int();
                Console.WriteLine("Введите номер номенклатуры:");
                while (!int.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine("Неверный ввод данных!");
                    Console.WriteLine("Введите номер номенклатуры:");
                }
                if (number < 1 || number > descriptions.Count)
                {
                    Console.WriteLine("Нет номенклатуры с таким номером");
                    return;
                }
                var description = descriptions[number - 1];


                var workLogEntries = new List<WorkLogEntry>();
                var status = "Изготавливается";

                var product = new Product(isDefective, releaseDateTime, serialNumber, description, workLogEntries, status);

                var workLogRepos = new WorkLogEntriesRepository(workLogEntries);
                Menu workLogMenu = new Menu();
                Console.Clear();

                workLogMenu.AddCommand(new MenuCommand("Добавить новую запись о рабочем времени"
                    , new AddWorkLogEntryExecutable(workLogRepos)));
                workLogMenu.AddCommand(new MenuCommand("Показать все записи"
                    , new ShowWorkLogExecutable(workLogRepos)));
                workLogMenu.AddCommand(new MenuCommand("Выпустить изделие"
                    , new CompleteProductExecutable(workLogMenu, product)));
                workLogMenu.AddCommand(new MenuCommand("Доработать изделие"
                , new RefineProductExecutable(workLogMenu, product)));
                workLogMenu.AddCommand(new MenuCommand("Утилизировать изделие"
                , new UtilizeProductExecutable(workLogMenu, product)));
                workLogMenu.Run();

                if (product.Status != "Утилизация")
                {
                    _productsRepository.AddProduct(product);
                }
            }
            catch(FormatException error)
            {
                Console.WriteLine(error.Message);
            }
            catch(FileNotFoundException error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
