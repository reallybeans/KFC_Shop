using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KFC_Food.Models
{    

    public class CartItem
    {   [Key]
        public TblProduct _shopping_product { get; set; }
        public int _shopping_quantity { get; set; }
    }
    public class Cart
    {

        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(TblProduct _product, int _quantity, int quantityRemain)
        {
            var item = items.FirstOrDefault(s => s._shopping_product.ProductId == _product.ProductId);
            if (item == null)
            {   
                items.Add(new CartItem
                {
                    _shopping_product = _product,
                    _shopping_quantity = _quantity
                });
            }
            else
            {
                if (quantityRemain <= item._shopping_quantity)
                {
                    return;
                }
                item._shopping_quantity += _quantity;
            }
        }

        public void Update_Quantity_Shopping(string id, int quantity)
        {
            var item = items.Find(s => s._shopping_product.ProductId == id);
            if (item != null)
            {
                item._shopping_quantity = quantity;
            }

        }

        public double TotalMoney()
        {
            var total = items.Sum(s => s._shopping_product.Price * s._shopping_quantity);
            return (double)total;
        }

        public void Remove_CartItem(string id)
        {
            items.RemoveAll(s => s._shopping_product.ProductId == id);

        }
        public int TotalQuantity()
        {
            return items.Sum(s => s._shopping_quantity);

        }

        public void ClearCart()
        {
           
        }
    }
}
