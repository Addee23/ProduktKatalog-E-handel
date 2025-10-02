using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProduktKatalog.Data;
using ProduktKatalog.Models;

namespace ProduktKatalog.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        public IActionResult AddToCart(int id, int quantity = 1)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            var cart = GetCart();

            var existingItem = cart.FirstOrDefault(c => c.ProductId == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity; // Lägg till det antal vi skickar in
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = quantity
                });
            }

            SaveCart(cart);
            return RedirectToAction("Index", "Products");
        }




        public IActionResult RemoveFromCart(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.ProductId == id);
            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
        }

        public IActionResult IncreaseQuantity(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.ProductId == id);
            if (item != null)
            {
                item.Quantity++;
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseQuantity(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.ProductId == id);
            if (item != null)
            {
                if (item.Quantity > 1)
                    item.Quantity--;
                else
                    cart.Remove(item); // ta bort om den blir 0

                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }



        private List<CartItem> GetCart()
        {
            var sessionCart = HttpContext.Session.GetString("Cart");
            if (String.IsNullOrEmpty(sessionCart))
            {
                return new List<CartItem>();
            }

            return JsonConvert.DeserializeObject<List<CartItem>>(sessionCart);
        }

        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
        }
    }
}
