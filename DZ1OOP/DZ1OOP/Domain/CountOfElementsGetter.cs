using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1OOP.Domain
{
    class CountOfElementsGetter
    {
        public int GetCountOfDefective(Batch batch)
        {
            int defectiveCount = 0;
            foreach (var product in batch.Products)
            {
                if (product.IsDefective)
                {
                    defectiveCount++;
                }
            }
            return defectiveCount;
        }

        public int GetCountOfInTime(Batch batch)
        {
            int inTimeCount = 0;
            foreach (var product in batch.Products)
            {
                if (product.TotalTimeSpent <= product.Description.StandardTime && !product.IsDefective)
                {
                    inTimeCount++;
                }
            }
            return inTimeCount;
        }

        public int GetCountOfNotInTime(Batch batch)
        {
            int notInTimeCount = 0;
            foreach (var product in batch.Products)
            {
                if (product.TotalTimeSpent > product.Description.StandardTime && !product.IsDefective)
                {
                    notInTimeCount++;
                }
            }
            return notInTimeCount;
        }

        public int GetCountWithArticle(Batch batch, string article)
        {
            int count = 0;
            foreach (var product in batch.Products)
            {
                if (product.Description.Article == article && !product.IsDefective)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
