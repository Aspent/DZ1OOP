using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ1OOP.Domain;

namespace DZ1OOP.Categories
{
    class FirstCategory : ICategory
    {
        public bool Belongs(Batch batch)
        {
            var elementsCountGetter = new CountOfElementsGetter();
            var extraTimeGetter = new ExtraTimeGetter();

            var defectiveCount = elementsCountGetter.GetCountOfDefective(batch);
            var inTimeCount = elementsCountGetter.GetCountOfInTime(batch);
            var notInTimeCount = elementsCountGetter.GetCountOfNotInTime(batch);

            var extraTime = extraTimeGetter.GetTotalExtraTime(batch);
            var extraTimeWithFirstArticle = extraTimeGetter.GetTotalExtraTimeWithArticle(batch, "SCOF-B1");
            var extraTimeWithSecondArticle = extraTimeGetter.GetTotalExtraTimeWithArticle(batch, "SCOY-ME2");

            var countWithFirstArticle = elementsCountGetter.GetCountWithArticle(batch, "SCOF-B1");
            var countWithSecondArticle = elementsCountGetter.GetCountWithArticle(batch, "SCOY-ME2");

            if ((float)defectiveCount / batch.Products.Count > 0.03)
            {         
                return false;
            }
            if ((float)inTimeCount / batch.Products.Count < 0.8)
            {
                return false;
            }
            if (extraTime > new TimeSpan(0, 5 * notInTimeCount, 0))
            {
                return false;
            }
            if (extraTimeWithFirstArticle > new TimeSpan(0, 3 * countWithFirstArticle, 0)) 
            {
                return false;
            }
            if (extraTimeWithSecondArticle > new TimeSpan(0, 4 * countWithSecondArticle, 0))
            {
                return false;
            }
            return true;
        }
    }
}
