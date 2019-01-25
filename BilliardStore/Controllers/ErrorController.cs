namespace BilliardStore.Controllers
{

    public class ErrorController : Microsoft.AspNetCore.Mvc.Controller
    {

        public Microsoft.AspNetCore.Mvc.ViewResult Error()
        {
            return View();
        }

        public ErrorController()
        {

        }

    }

}
