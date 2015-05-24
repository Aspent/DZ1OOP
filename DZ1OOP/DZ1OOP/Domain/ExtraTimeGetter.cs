using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1OOP.Domain
{
    class ExtraTimeGetter
    {
        public TimeSpan GetTotalExtraTimeWithArticle(Batch batch, string article)
        {
            var extraTime = new TimeSpan();
            foreach (var product in batch.Products)
            {
                if (!product.IsDefective)
                {
                    if (product.TotalTimeSpent > product.Description.StandardTime &&
                        product.Description.Article == article)
                    {
                        extraTime += product.TotalTimeSpent - product.Description.StandardTime;
                    }
                }
            }
            return extraTime;
        }

        public TimeSpan GetTotalExtraTime(Batch batch)
        {
            var extraTime = new TimeSpan();
            foreach (var product in batch.Products)
            {
                if (!product.IsDefective)
                {
                    if (product.TotalTimeSpent > product.Description.StandardTime)
                    {
                        extraTime += product.TotalTimeSpent - product.Description.StandardTime;
                    }
                }
            }
            return extraTime;
        }
    }
}
