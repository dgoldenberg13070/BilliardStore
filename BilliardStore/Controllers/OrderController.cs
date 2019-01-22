//Calls Cart.cs

using System.Linq;

namespace BilliardStore.Controllers
{

    public class OrderController : Microsoft.AspNetCore.Mvc.Controller
    {
        private Models.IOrderRepository repository;
        private Models.Cart cart;
        private readonly SendGrid.ISendGridClient _sendGridClient;
        private readonly Braintree.IBraintreeGateway _braintreeGateway;

        public OrderController(Models.IOrderRepository repoService, Models.Cart cartService, SendGrid.ISendGridClient sendGridClient, Braintree.IBraintreeGateway braintreeGateway)
        {
            repository = repoService;
            cart = cartService;
            _sendGridClient = sendGridClient;
            _braintreeGateway = braintreeGateway;
        }
        
        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ViewResult> Checkout()
        {
            ViewBag.BraintreeClientToken = await _braintreeGateway.ClientToken.GenerateAsync();
            return View(new Models.Order());
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> Checkout(Models.Order order, string braintreeNonce)
        {

            //next line calls the Lines method in Cart.cs
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Your shopping cart is empty!");
            }

            if (ModelState.IsValid)
            {
                Braintree.TransactionRequest transactionRequest = new Braintree.TransactionRequest
                {
                    Amount = cart.Lines.Sum(x => x.Quantity * x.Product.Price),
                    PaymentMethodNonce = braintreeNonce
                };
                var transactionResult = await _braintreeGateway.Transaction.SaleAsync(transactionRequest);              
                order.PlacementDate = System.DateTime.UtcNow;
                order.TrackingNumber = System.Guid.NewGuid().ToString().Substring(0, 8);
                order.SubTotal = cart.Lines.Sum(x => x.Quantity * x.Product.Price);
                order.Total = cart.Lines.Sum(x => x.Quantity * x.Product.Price);
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                int z = 99;
                if (z != 99)
                {
                    var message = new SendGrid.Helpers.Mail.SendGridMessage
                    {
                        From = new SendGrid.Helpers.Mail.EmailAddress(
                       "admin@sbilliardstore.codingtemple.com", "Chalky's Billiard Store Administration"),
                        Subject = "Receipt for order #" + order.OrderID,
                        HtmlContent = "Thanks for your order!"
                    };
                    message.AddTo(order.Email);
                    var result = await _sendGridClient.SendEmailAsync(message);
                    //This can be helpful debug code, but we wont display it out to the user:
                    var responseBody = await result.DeserializeResponseBodyAsync(result.Body);
                    if (responseBody != null)
                    {
                        foreach (var body in responseBody)
                        {
                            System.Console.WriteLine(body.Key + ":" + body.Value);
                        }
                    }                                     
                }                
                return RedirectToAction(nameof(Completed), new { id = order.TrackingNumber });
            }
            else
            {
                return View(order);
            }

        }

        public Microsoft.AspNetCore.Mvc.ViewResult Completed(string id)
        {
            Models.Order order = repository.Orders.Single(x => x.TrackingNumber == id);
            cart.Clear();
            return View(order);
        }

    }
    
}
