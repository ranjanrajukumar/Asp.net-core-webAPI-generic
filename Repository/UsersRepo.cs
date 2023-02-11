using ApiCrudUsingGeneric.DAL;
using ApiCrudUsingGeneric.IService;
using ApiCrudUsingGeneric.Models;
using System.Data.SqlClient;

namespace ApiCrudUsingGeneric.Repository
{
    public class UsersRepo : AdoRepository<Users>, IUsersService
    {
        public UsersRepo(string connectionString) : base(connectionString)
        {
        }

        public List<Users> GetAll()
        {
            using (var command = new SqlCommand("Select * from Users"))
            {
                return GetRecords(command).ToList();
            }
        }

        public Users GetById(string id)
        {
            using (var command = new SqlCommand("Select * from Users where Id = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return GetRecord(command);
            }
        }
    }

}
