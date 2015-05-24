using System;
using System.Collections.Generic;

namespace DZ1OOP.Domain
{
    class Batch
    {
        #region Fields

        private readonly string _barcode;
        private readonly DateTime _releaseDate;
        private readonly List<Product> _products;

        #endregion

        #region Constructor

        public Batch(string barcode, DateTime releaseDate, List<Product> products)
        {
            _barcode = barcode;
            _releaseDate = releaseDate;
            _products = products;
        }

        #endregion

        #region Properties

        public string Barcode
        {
            get { return _barcode; }
        }

        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
        }

        public List<Product> Products
        {
            get { return _products; }
        }


        #endregion
    }
}
