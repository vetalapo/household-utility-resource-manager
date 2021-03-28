using System.Diagnostics;

using HurManager.App.Common.Operation;

using Microsoft.AspNetCore.Mvc;

namespace HurManager.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult ApiNotFound()
        {
            var result = OperationResult.Fail("Endpoint not found");

            return this.Ok(result);
        }

        public IActionResult Error(int? stasusCode = null)
        {
            this.ViewData["RequestId"] = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier;

            return this.View("Error");
        }

        public IActionResult Index()
        {
            return this.View("Index");
        }
    }
}
