using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1OOP.Domain
{
    class BatchesRepository
    {
        private List<Batch> _batches;

        public BatchesRepository()
        {
            _batches = new List<Batch>();
        }

        public BatchesRepository(List<Batch> batches)
        {
            _batches = batches;
        }

        public List<Batch> GetAll()
        {
            return _batches;
        }

        public Batch GetByNumber(int number)
        {
            if (number >= 1 && number <= _batches.Count)
            {
                return _batches[number - 1];
            }
            return null;
        }

        public void AddBatch(Batch batch)
        {
            _batches.Add(batch);
        }

        public int Count
        {
            get { return _batches.Count; }
        }
    }
}
