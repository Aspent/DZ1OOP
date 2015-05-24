using System;
using DZ1OOP.Domain;
using DZ1OOP.MenuEngine;

namespace DZ1OOP.Executables
{
    class AddWorkLogEntryExecutable : IExecutable
    {
        private WorkLogEntriesRepository _workLogEntriesRepository;

        public AddWorkLogEntryExecutable(WorkLogEntriesRepository repository)
        {
            _workLogEntriesRepository = repository;
        }

        public void Execute()
        {
            var dateTime = DateTime.Now;
            const string description = "Работа над изделием прошла нормально";
            const string responsible = "Иванов Петр Сергеевич";
            var timeSpent = new TimeSpan();
            Console.WriteLine("Введите время, затраченное на изготовление изделия (в формате час:минута:секунда)");
            while(!TimeSpan.TryParse(Console.ReadLine(), out timeSpent))
            {
                Console.WriteLine("Введены неверне данные");
                Console.WriteLine("Введите время, затраченное на изготовление изделия (в формате час:минута:секунда)");
            }
            var workLogEntry = new WorkLogEntry(dateTime, description, responsible, timeSpent);
            _workLogEntriesRepository.AddWorkLogEntry(workLogEntry);
        }
    }
}
