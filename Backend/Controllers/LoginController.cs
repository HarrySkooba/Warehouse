using Backend;
using Microsoft.AspNetCore.Mvc;
using WebApi.DB;



[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUserService _userService;


    public LoginController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public IActionResult CheckLogin([FromBody] User loginModel)
    {
        var user = _userService.GetUserByLogin(loginModel.Name, loginModel.Password);

        if (user.Name == null)
        {
            return BadRequest("Пользователь с указанным логином не найден.");
        }

        if (user.Password != loginModel.Password)
        {
            return BadRequest("Неверный пароль.");
        }

        return Ok("Вход выполнен успешно!");
    }
}
