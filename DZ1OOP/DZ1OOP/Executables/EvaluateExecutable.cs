using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ1OOP.Domain;
using DZ1OOP.MenuEngine;
using DZ1OOP.Categories;

namespace DZ1OOP.Executables
{
    class EvaluateExecutable : IExecutable
    {
        private readonly BatchesRepository _batchesRepository;

        public EvaluateExecutable(BatchesRepository repository)
        {
            _batchesRepository = repository;
        }
        public void Execute()
        {
            var categories = new List<ICategory>();
            categories.Add(new FirstCategory());
            categories.Add(new SecondCategory());
            categories.Add(new ThirdCategory());
            categories.Add(new FourthCategory());
            categories.Add(new FifthCategory());

            var number = new int();
            Console.WriteLine("Введите номер партии");
            while(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Неверный ввод данных");
                Console.WriteLine("Введите номер партии");
            }
            if(number < 1 || number > _batchesRepository.Count)
            {
                Console.WriteLine("Нет партии с таким номером");
                return;
            }

            var batch = _batchesRepository.GetByNumber(number);
            for(int i=1; i<=categories.Count; i++)
            {
                if(categories[i-1].Belongs(batch))
                {
                    Console.WriteLine("{0}-я категория", i);
                    break;
                }
            }
        }
    }
}
