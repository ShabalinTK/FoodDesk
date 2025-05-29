using FoodDesk.Application.Features.Auth.Queries.Login;
using FoodDesk.WEB.Models.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodDesk.WEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var query = new LoginQuery(model.Email, model.Password);

            var IsSuccess = await _mediator.Send(query);

            if (IsSuccess)
                return RedirectToAction("Index", "Home");

            //ModelState.AddModelError(string.Empty, result.Error);
            return View(model);
        }
    }
}
