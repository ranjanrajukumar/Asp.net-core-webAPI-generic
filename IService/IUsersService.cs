using ApiCrudUsingGeneric.Models;

namespace ApiCrudUsingGeneric.IService
{
    public interface IUsersService
    {
        List<Users> GetAll();
        Users GetById(string id);
    }
}
