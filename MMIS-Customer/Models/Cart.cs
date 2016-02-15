using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMIS_Customer.Models
{
    public class Cart
    {
        public Cart()
        {
            CustomerPurchaseItems = new List<ProductStock>();
            
        }

        public List<ProductStock> CustomerPurchaseItems { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return CustomerPurchaseItems.Sum(x => x.Product.Price * x.Quantity);
            }
        }
         

        public void AddToCart(Product product, Store store, int quantity)
        {
            
            ProductStock productStock = CustomerPurchaseItems.FirstOrDefault(x => x.ProductID == product.ProductID &&
                x.StoreID == store.StoreID);

            if (productStock == null)
            {
                CustomerPurchaseItems.Add(new ProductStock
                {	
                    ProductID = product.ProductID,
                    Product = product,
                    StoreID = store.StoreID,
                    Store = store,
                    Quantity = quantity,
                   
                });

                
            }
            else 
            {
                productStock.Quantity = quantity;
            }
        }



        public void RemoveFromCart(Product product, int index)
        {
            var item = CustomerPurchaseItems.First(x => x.ProductID == index);
            CustomerPurchaseItems.Remove(item);
        }


        public void ChangeQuantity(Product product, int index, int quantity)
        {
            var item = CustomerPurchaseItems.First(x => x.ProductID == index);
            item.Quantity = quantity;
        }



    }
}