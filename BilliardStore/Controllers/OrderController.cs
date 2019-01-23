//Calls Cart.cs

//using SmartyStreets.USAutocompleteApi;
//using SmartyStreets.USExtractApi;
using System.Linq;

namespace BilliardStore.Controllers
{

    public class OrderController : Microsoft.AspNetCore.Mvc.Controller
    {
        private Models.IOrderRepository repository;
        private Models.Cart cart;
        private readonly SendGrid.ISendGridClient _sendGridClient;
        private readonly Braintree.IBraintreeGateway _braintreeGateway;
        private readonly SmartyStreets.IClient<SmartyStreets.USStreetApi.Lookup> _usStreetClient;
        readonly string debug = "false";

        public OrderController(Models.IOrderRepository repoService, Models.Cart cartService, SendGrid.ISendGridClient sendGridClient, Braintree.IBraintreeGateway braintreeGateway, SmartyStreets.IClient<SmartyStreets.USStreetApi.Lookup> usStreetClient)
        {
            repository = repoService;
            cart = cartService;
            _sendGridClient = sendGridClient;
            _braintreeGateway = braintreeGateway;
            _usStreetClient = usStreetClient;
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
                Braintree.CustomerRequest customer = new Braintree.CustomerRequest();
                //    if (User.Identity.IsAuthenticated)
                //   {
                //       var user = _context.Users.Single(x => x.UserName == User.Identity.Name);
                //       customer.Email = user.Email;
                //       customer.FirstName = user.FirstName;
                //       customer.LastName = user.LastName;
                //       customer.Phone = user.PhoneNumber;
                //   }
                //   else
                //   {
                        customer.Email = order.Email;
                        customer.Phone = order.Phone;
                //   }

                Braintree.TransactionRequest transactionRequest = new Braintree.TransactionRequest
                {
                    Amount = cart.Lines.Sum(cartItem => cartItem.Quantity * cartItem.Product.Price),
                    PaymentMethodNonce = order.BraintreeNonce,
                    Customer = customer,
                    LineItems = cart.Lines.Select(cartItem => new Braintree.TransactionLineItemRequest
                    {
                        UnitAmount = cartItem.Product.Price,
                        Name = cartItem.Product.Name,
                        Description = cartItem.Product.Description,
                        Quantity = cartItem.Quantity,
                        TotalAmount = cartItem.Quantity * cartItem.Product.Price,
                        ProductCode = cartItem.ProductID.ToString(),
                        LineItemKind = Braintree.TransactionLineItemKind.DEBIT
                    }).ToArray()
                };
                var transactionResult = await _braintreeGateway.Transaction.SaleAsync(transactionRequest);
                order.PlacementDate = System.DateTime.UtcNow;
                order.TrackingNumber = System.Guid.NewGuid().ToString().Substring(0, 8);
                order.SubTotal = cart.Lines.Sum(x => x.Quantity * x.Product.Price);
                order.Total = cart.Lines.Sum(x => x.Quantity * x.Product.Price);
                order.Lines = cart.Lines.ToArray();                
                repository.SaveOrder(order);                
                if (debug != "true")
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
                ViewBag.BraintreeClientToken = await _braintreeGateway.ClientToken.GenerateAsync();
                return View(order);
            }

        }

        public Microsoft.AspNetCore.Mvc.ViewResult Completed(string id)
        {
            Models.Order order = repository.Orders.Single(x => x.TrackingNumber == id);
            cart.Clear();
            return View(order);
        }

        public Microsoft.AspNetCore.Mvc.IActionResult ValidateAddress(string street, string street2, string city, string state, string zipCode)
        {
          //  if (string.IsNullOrEmpty(street) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(state))
          //  {
          //      return BadRequest("street, city, state, and zipCode are required");
          //  }
            SmartyStreets.USStreetApi.Lookup lookup = new SmartyStreets.USStreetApi.Lookup
            {
                Street = street,
                Street2 = street2,
                City = city,
                State = state,
                ZipCode = zipCode
            };
            if (debug != "true")
            {
                _usStreetClient.Send(lookup);
            }
            return Json(lookup.Result.ToArray());
        }

    }
    
}