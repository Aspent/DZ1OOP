using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ1OOP.Domain;
using DZ1OOP.MenuEngine;

namespace DZ1OOP.Executables
{
    class DescriptionPrinter
    {
        private readonly List<ProductDescription> _repository;

        public DescriptionPrinter()
        {
            _repository = new List<ProductDescription>();
        }

        public DescriptionPrinter(List<ProductDescription> repository)
        {
            _repository = repository;
        }

        public void PrintByNumber(int number)
        {
            var description = _repository[number - 1];
            Console.WriteLine("Артикул: {0}", description.Article);
            Console.WriteLine("Норма рабочего времени: {0}", description.StandardTime);
            Console.WriteLine("Название: {0}", description.Title);       
        }

        public void PrintAll()
        {
            for(int i=1; i <= _repository.Count; i++)
            {
                Console.WriteLine("Введите {0}, чтобы выбрать эту номенклатуру", i);
                PrintByNumber(i);
                Console.WriteLine();
            }
        }

        public void PrintDescription(ProductDescription description)
        {
            Console.WriteLine("Артикул: {0}", description.Article);
            Console.WriteLine("Норма рабочего времени: {0}", description.StandardTime);
            Console.WriteLine("Название: {0}", description.Title);
        }
    }
}
