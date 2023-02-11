using ApiCrudUsingGeneric.DAL;
using ApiCrudUsingGeneric.DAO;
using ApiCrudUsingGeneric.IService;
using ApiCrudUsingGeneric.Models;
using ApiCrudUsingGeneric.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Net;
using System.Reflection;
using System.Xml.Linq;

namespace ApiCrudUsingGeneric.Service
{
    //public class UsersService : IUsersService
    //{
    //    private readonly IUsersRepo _usersRepo;
    //    public UsersService(IOptions <DataConnection> options)
    //    {
    //        var connection = options.Value;
    //        UsersRepo usersRepo = new UsersRepo(connection.DefaultConnection);
    //        _usersRepo = (IUsersRepo?)usersRepo;
    //    }
    //    public List<Users> GetAll()
    //    {
    //       return _usersRepo.GetAll().ToList();
    //    }

    //    public Users GetById(string id)
    //    {
    //        return _usersRepo.GetById(id);
    //    }
    //}





    public class UsersService : IGenericService<Users>
    {
        List<Users> _Users = new List<Users>();
        //private readonly IOptions<DataConnection> appSettings;
        private IConfiguration Configuration;

        public UsersService(IConfiguration _configuration)
        {
            Configuration = _configuration;

            string connString = this.Configuration.GetConnectionString("DefaultConnection");
            //public UsersService(IOptions<DataConnection> app)
            //{
            // appSettings = app;
            UsersDao userSer = new UsersDao();
            //_Users = userSer.GetAllUsers(appSettings.Value.DefaultConnection);
            _Users = userSer.GetAllUsers(connString);
            //for (int i = 1; i <= 9; i++)
            //{
            //    _Users.Add(new Users()
            //    {
            //        Id = i,
            //        Name = "User" + i,
            //        EmailId = "User@" + i,
            //        Mobile = "987654321" + i,
            //        Address = "Address" + i
            //    });
            //}
        }
        public List<Users> Delete(int id)
        {
            _Users.RemoveAll(x => x.Id == id);
            return _Users;
        }

        public List<Users> GetAll()
        {
            return _Users;
        }

        public Users GetById(int id)
        {
            return _Users.Where(x => x.Id == id).SingleOrDefault();
        }

        public List<Users> Insert(Users item)
        {
            _Users.Add(item);
            return _Users;
        }
    }
}
