using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KFC_Food.Data;
using KFC_Food.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace KFC_Food.Controllers

{
    public class ShoppingCartController : Controller
    {

        private readonly KFC_DATAContext _context;

        public ShoppingCartController(KFC_DATAContext context)
        {
            _context = context;
        }

        public Cart GetCart()
        {
            Cart cart = null;
            try
            {
                 cart = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("Cart"));
            }
            catch
            {
            }
            if (cart == null || HttpContext.Session.GetString("Cart") == null)
            {
                cart = new Cart();
                HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            }

            return cart;
            


        }
        public IActionResult AddToCart(string productID,string search)
        {
            TblUser user = null;
            try
            {
                 user = JsonConvert.DeserializeObject<TblUser>(HttpContext.Session.GetString("User"));
            }
            catch
            {
                return RedirectToAction("Login", "ShoppingCart");
            }


            var pro = _context.TblProducts.SingleOrDefault(s => s.ProductId == productID);
            if (pro != null)
            {                 
                Cart cart = GetCart();
                int quantityRemain = pro.Quantity;
                CartItem item = cart.Items.FirstOrDefault(x => x._shopping_product.ProductId == productID);
                if (item != null)
                {   
                    
                    if (item._shopping_quantity >= quantityRemain )
                    {
                        TempData["Message"] = "Product out of stock!";
                        return RedirectToAction("Index", "Home");
                    }
                }
                if (quantityRemain == 0)
                {
                    TempData["Message"] = "Product out of stock!";
                    return RedirectToAction("Index", "Home");
                }
                cart.Add(pro, 1,quantityRemain);
                HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            }
            TempData["SearchValue"] = search;
            TempData["Message"] = "Add new success!";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ShowToCart()
        {
            Cart cart = null;
            
            try
            {
                cart = GetCart();
                ViewData["Message"] = TempData["Message"].ToString();
                return View(cart);
            }
            catch
            {
            }

            try
            {
                cart = GetCart();
                ViewData["SoldOutList"] = TempData["SoldOutList"];
                return View(cart);
            }
            catch
            {

            }

            return View(cart);

        }

        public IActionResult Update_Quantity_Cart(IFormCollection form)
        {
            Cart cart = null;
            try
            {
                cart = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("Cart"));
            }
            catch
            { 
            }
            string id_pro = form["productID"];
            int quantity = Int32.Parse(form["quantity"]);

            TblProduct pro = _context.TblProducts.SingleOrDefault(s => s.ProductId == id_pro);
            int quantityRemain = pro.Quantity;
            if (quantityRemain < quantity)
            {
                TempData["Message"] = "Out of stock!";
                return RedirectToAction("ShowToCart", "ShoppingCart");
            }
            cart.Update_Quantity_Shopping(id_pro, quantity);
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            TempData["Message"] = "Update success!";
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        public IActionResult Remove_CartItem(string id)
        {
            Cart cart = null;
            try
            {
                cart = JsonConvert.DeserializeObject<Cart>(HttpContext.Session.GetString("Cart"));
            }
            catch
            {
            }
            cart.Remove_CartItem(id);
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            TempData["Message"] = "Remove success!";
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }



        public IActionResult Login()
        {
            ViewData["Message"] = TempData["Message"];
            return View();
        }

        public IActionResult CheckOutForm()
        {
            return View();
        }

        public async Task<IActionResult> CheckOut(IFormCollection form)
        {
            TblUser user = null;
            Cart cart = null;
            try
            {
                user = JsonConvert.DeserializeObject<TblUser>(HttpContext.Session.GetString("User"));
                cart = GetCart();
            }
            catch {}
            List<String> soldOutList = new List<string>();
            bool check = true;
            try
            {
                foreach (var item in cart.Items)
                {
                    TblProduct pro = _context.TblProducts.Find(item._shopping_product.ProductId);
                    if (pro != null)
                    {
                        if (pro.Quantity < item._shopping_quantity)
                        {
                            soldOutList.Add(pro.ProductName + " out of stock! Available " + pro.Quantity + " products! ");
                            check = false;
                        }
                    }
                }

            }
            catch
            {
            }
            if (!check)
            {
                TempData["SoldOutList"] = soldOutList;
                return RedirectToAction("ShowToCart", "ShoppingCart");
            }
            if (cart != null)
            {   
                string orderID = GetOrderID();
                ViewData["OrderID"] = orderID;
                string userName = user.UserName;
                string name = user.Name;
                ViewData["Name"] = name;
                string address = form["address"];
                ViewData["Address"] = address;
                string phone = form["phone"];
                ViewData["Phone"] = phone;
                string paymentType = "Cash";
                ViewData["Payment_Type"] = paymentType;
                float totalPrice = (float)cart.TotalMoney();
                ViewData["Total_Price"] = totalPrice;
                DateTime time = DateTime.Now;
                ViewData["Time"] = time;
                TblOrder order = new TblOrder();
                order.OrderId = orderID;
                order.UserName = userName;
                order.Name = name;
                order.Address = address;
                order.Phone = phone;
                order.PaymentType = paymentType;
                order.TotalPrice = totalPrice;
                order.Time = time;
                _context.TblOrders.Add(order);
                await _context.SaveChangesAsync();
                await AddOrderDetails(orderID, cart);
                HttpContext.Session.Remove("Cart");
               
            }         
            
            return View();
        }

        public string GetOrderID()
        {
            while (true)
            {
                Random random = new Random();
                const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
                var builder = new StringBuilder();

                for (var i = 0; i < 20; i++)
                {
                    var c = pool[random.Next(0, pool.Length)];
                    builder.Append(c);
                }
                string orderID = builder.ToString();
                if (_context.TblOrders.Find(orderID) == null)
                {
                    return orderID.ToUpper();
                }              
            }
        }
        
        public async Task AddOrderDetails(string orderID, Cart cart)
        {
            foreach (var item in cart.Items)
            {
                TblOrderDetail detail = new TblOrderDetail();
                detail.OrderId = orderID;
                detail.ProductId = item._shopping_product.ProductId;
                detail.Quantity = item._shopping_quantity;
                detail.Price = item._shopping_product.Price;
                _context.TblOrderDetails.Add(detail);
                
                await _context.SaveChangesAsync();
                TblProduct product = _context.TblProducts.SingleOrDefault(s => s.ProductId == item._shopping_product.ProductId);
                if (product != null)
                {
                    product.Quantity = product.Quantity - item._shopping_quantity;
                    _context.TblProducts.Update(product);
                    await  _context.SaveChangesAsync();
                }
            }
        }
        
    }
}
