using System;
using System.Collections;

namespace Wasted.Data
{
    public class ProductList : IEnumerable
    {
        private Product[] _productList;

        public ProductList(Product[] products)
        {
            _productList = new Product[products.Length];

            for (int i = 0; i < products.Length; i++)
            {
                _productList[i] = products[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return (IEnumerator) GetEnumerator();
        }


        public ProductListEnum GetEnumerator()
        {
            return new ProductListEnum(_productList);
        }
    }

    public class ProductListEnum : IEnumerator
    {
        public Product[] _productList;

        int position = -1;

        public ProductListEnum(Product[] list)
        {
            _productList = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _productList.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Product Current
        {
            get
            {
                try
                {
                    return _productList[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
