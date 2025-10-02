using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProduktKatalog.Models;

namespace ProduktKatalog.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var sessionCart = HttpContext.Session.GetString("Cart");
            var cart = string.IsNullOrEmpty(sessionCart)
                ? new List<CartItem>()
                : JsonConvert.DeserializeObject<List<CartItem>>(sessionCart)!;

            int totalItems = cart.Sum(c => c.Quantity);

            // Returnera bara siffran så att den kan ersätta badge-texten
            return Content(totalItems.ToString());
        }
    }
}
