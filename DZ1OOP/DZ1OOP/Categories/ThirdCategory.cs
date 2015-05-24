using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ1OOP.Domain;

namespace DZ1OOP.Categories
{
    class ThirdCategory : ICategory
    {
        public bool Belongs(Batch batch)
        {
            var elementsCountGetter = new CountOfElementsGetter();
            var extraTimeGetter = new ExtraTimeGetter();

            var defectiveCount = elementsCountGetter.GetCountOfDefective(batch);
            var inTimeCount = elementsCountGetter.GetCountOfInTime(batch);
            var notInTimeCount = elementsCountGetter.GetCountOfNotInTime(batch);

            var extraTime = extraTimeGetter.GetTotalExtraTime(batch);
            var extraTimeWithArticle = extraTimeGetter.GetTotalExtraTimeWithArticle(batch, "WVP-B1");

            var countWithArticle = elementsCountGetter.GetCountWithArticle(batch, "WVP-B1");

            if ((float)defectiveCount / batch.Products.Count > 0.06)
            {
                return false;
            }
            if ((float)inTimeCount / batch.Products.Count < 0.75)
            {
                return false;
            }
            if (extraTime > new TimeSpan(0, 6 * notInTimeCount, 0))
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
