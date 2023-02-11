using ApiCrudUsingGeneric.IService;
using ApiCrudUsingGeneric.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudUsingGeneric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //public class UsersController
    //{
    //    private readonly IUsersService _userService;
    //    public UsersController(IUsersService userService)
    //    {
    //        _userService = userService;
    //    }
    //    //public IActionResult Index()
    //    //{
    //    //    var users = _userService.GetAll();
    //    //    return ((IActionResult)users);
    //    //}
    //}



    public class UsersController : GenericController<Users>
    {
        public UsersController(IGenericService<Users> genericService) : base(genericService)
        {
        }
    }
}
