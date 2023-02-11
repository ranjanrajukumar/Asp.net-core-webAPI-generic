using ApiCrudUsingGeneric.Models;

namespace ApiCrudUsingGeneric.Repository
{
    public interface IUsersRepo
    {
        List<Users> GetAll();
        Users GetById(string id);
    }
}
