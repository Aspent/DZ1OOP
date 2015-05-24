using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1OOP.Domain
{
    class ProductDescriptionsRepository : IDescriptionSource
    {
        private readonly List<ProductDescription> _productDescriptions;

        public ProductDescriptionsRepository()
        {
            _productDescriptions = new List<ProductDescription>();
            _productDescriptions.Add(new ProductDescription("SCOF-B1", new TimeSpan(1, 30, 0), "Тарелка"));
            _productDescriptions.Add(new ProductDescription("SCOY-ME2", new TimeSpan(0, 45, 0), "Ложка"));
            _productDescriptions.Add(new ProductDescription("WVP-B2", new TimeSpan(0, 55, 0), "Вилка"));
            _productDescriptions.Add(new ProductDescription("WVP-B1", new TimeSpan(1, 10, 0), "Кружка"));
            _productDescriptions.Add(new ProductDescription("WVTGN-MRL", new TimeSpan(2, 15, 0), "Кастрюля"));
            _productDescriptions.Add(new ProductDescription("0000006", new TimeSpan(2, 26, 0), "Стол"));
            _productDescriptions.Add(new ProductDescription("0000007", new TimeSpan(1, 17, 0), "Стул"));
            _productDescriptions.Add(new ProductDescription("0000008", new TimeSpan(3, 05, 0), "Шкаф"));
            _productDescriptions.Add(new ProductDescription("0000009", new TimeSpan(2, 49, 0), "Диван"));
            _productDescriptions.Add(new ProductDescription("0000010", new TimeSpan(1, 58, 0), "Кресло"));
        }

        public void AddDescription(ProductDescription description)
        {
            _productDescriptions.Add(description);
        }

        public List<ProductDescription> GetListOfDescriptions()
        {
            return _productDescriptions;
        }
    }
}
