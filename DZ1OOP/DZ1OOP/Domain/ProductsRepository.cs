using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1OOP.Domain
{
    class ProductsRepository
    {
        private List<Product> _products;

        public ProductsRepository()
        {
            _products = new List<Product>();
        }

        public ProductsRepository(List<Product> products)
        {
            _products = products;
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetByNumber(int number)
        {
            if(number >= 1 && number <= _products.Count)
            {
                return _products[number - 1];
            }
            return null;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            _products.Remove(product);
        }

        public int Count
        {
            get { return _products.Count; }
        }
    }
}
