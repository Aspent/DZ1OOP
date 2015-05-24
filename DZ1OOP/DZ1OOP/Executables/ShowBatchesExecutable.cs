using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ1OOP.Domain;
using DZ1OOP.MenuEngine;

namespace DZ1OOP.Executables 
{
    class ShowBatchesExecutable : IExecutable
    {
        private readonly BatchesRepository _batchesRepository;

        public ShowBatchesExecutable(BatchesRepository repository)
        {
            _batchesRepository = repository;
        }

        public void Execute()
        {
            var batches = _batchesRepository.GetAll();
            for (var i = 1; i <= batches.Count; i++)
            {
                Console.WriteLine("{0}: {1}, {2}", i, batches[i-1].Barcode, batches[i-1].ReleaseDate);
                Console.WriteLine();
            }
        }

    }
}
