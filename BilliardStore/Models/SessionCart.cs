//calls SessionExtension.cs, Cart.cs
//called by CartController.cs

using Microsoft.Extensions.DependencyInjection;
using BilliardStore.Infrastructure;

namespace BilliardStore.Models
{

    public class SessionCart : Cart
    {

        public static Cart GetCart(System.IServiceProvider services)
        {
            Microsoft.AspNetCore.Http.ISession session = services.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [Newtonsoft.Json.JsonIgnore]
        public Microsoft.AspNetCore.Http.ISession Session { get; set; }

        //called by CartController.cs
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }

    }

}

