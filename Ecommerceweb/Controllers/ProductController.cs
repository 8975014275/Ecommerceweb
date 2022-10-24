using Ecommerceweb.DAL;
using Ecommerceweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Ecommerceweb.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL db = new ProductDAL();
        CartDAL cd = new CartDAL();
        public IActionResult Index()
        {
            var model = db.GetAllProducts();
            return View(model);
        }

        public IActionResult AddProductToCart(int id)
        {
            string userid = HttpContext.Session.GetString("userid");
            Cart cart = new Cart();
            cart.ProductId = id;
            cart.UserId = Convert.ToInt32(userid);
            

            int res = cd.AddToCart(cart);
            if (res == 1)
            {
                return RedirectToAction("ViewCart");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult ViewCart()
        {
            string userid = HttpContext.Session.GetString("userid");
            var model = cd.ViewProductsFromCart(userid);
            return View(model);
        }

        [HttpGet]
        public IActionResult RemoveFromCart(int id)
        {
            int res = cd.RemoveFromCart(id);
            if (res == 1)
            {
                return RedirectToAction("ViewCart");
            }
            else
            {
                return View();
            }
        }
        public IActionResult AddProductToOrder(int id)
        {
            string userid = HttpContext.Session.GetString("userid");
            Orders ord = new Orders();
            ord.OrderId = id;
            ord.ProductId = id;
            ord.UserId = Convert.ToInt32(userid);
            int res = cd.AddToOrder(ord);
            if (res == 1)
            {
                return RedirectToAction("PlaceOrder");
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public IActionResult PlaceOrder(int id)
        {
            string userid = HttpContext.Session.GetString("userid");
            var product = db.GetProductById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult submit(Product product)
        {
            string userid = HttpContext.Session.GetString("userid");
            Orders orderDetails = new Orders();
            orderDetails.ProductId = product.ProductId;
            orderDetails.Quantity = product.Quantity;
            orderDetails.UserId = Convert.ToInt32(userid);
            int result = cd.AddToOrder(orderDetails);
            if (result == 1)
            {
                return RedirectToAction("Success");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Success()
        {
            string userid = HttpContext.Session.GetString("userid");
            var model = cd.ViewProductsFromOrder(userid);
            return View(model);
        }


    }
}
