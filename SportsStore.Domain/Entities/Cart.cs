using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity,int isUpdate = 0)
        {
            CartLine line = lineCollection.
                Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else if(isUpdate == 0)
            {
                line.Quantity += quantity;
            }
            else
            {
                line.Quantity = quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(r => r.Product.ProductID == product.ProductID);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(s => s.Product.AltPrice * s.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public IEnumerable<CartLine> Lines
        {
            get
            {
                return lineCollection;
            }
        }
    }
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }    
}
