using FoodDesk.Application.Features.Auth.Command.Register;
using FoodDesk.WEB.Models.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodDesk.WEB.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IMediator _mediator;
        public RegisterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var command = new RegisterCommand
            { 
                UserName = model.UserName,
                Email = model.Email, 
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword
            };

            var IsSuccess = await _mediator.Send(command);

            if (IsSuccess)
                return RedirectToAction("Index", "Home");

            //ModelState.AddModelError(string.Empty, result.Error);
            return View(model);
        }
    }
}
