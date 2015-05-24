using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ1OOP.Domain;

namespace DZ1OOP.Categories
{
    class SecondCategory : ICategory
    {
        public bool Belongs(Batch batch)
        {
            var elementsCountGetter = new CountOfElementsGetter();
            var extraTimeGetter = new ExtraTimeGetter();

            var defectiveCount = elementsCountGetter.GetCountOfDefective(batch);
            var inTimeCount = elementsCountGetter.GetCountOfInTime(batch);
            var notInTimeCount = elementsCountGetter.GetCountOfNotInTime(batch);

            var extraTime = extraTimeGetter.GetTotalExtraTime(batch);
            var extraTimeWithArticle = extraTimeGetter.GetTotalExtraTimeWithArticle(batch, "WVP-B2");

            var countWithArticle = elementsCountGetter.GetCountWithArticle(batch, "WVP-B2");
      
            if ((float)defectiveCount / batch.Products.Count > 0.05)
            {
                return false;
            }
            if ((float)inTimeCount / batch.Products.Count < 0.75)
            {
                return false;
            }
            if (extraTime > new TimeSpan(0, 5 * notInTimeCount, 0))
            {
                return false;
            }
            if (extraTimeWithArticle > new TimeSpan(0, 4 * countWithArticle, 0))
            {
                return false;
            }
            return true;
        }
    }
}
