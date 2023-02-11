using ApiCrudUsingGeneric.Models;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ApiCrudUsingGeneric.DAO
{
    public class UsersDao
    {
       //private readonly IConfiguration _configuration;

        public UsersDao()
        {
        }

        //public UsersDao(IConfiguration configuration) => _configuration = configuration;

        public List<Users> GetAllUsers(string con1)
        {
            List<Users> lstmain = new List<Users>();
            //SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlConnection con = new SqlConnection(con1);
            StringBuilder strQuery = new StringBuilder();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            strQuery.Append("Select * from Users");
            cmd.CommandText = strQuery.ToString();
            SqlDataAdapter da = new(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Users obj = new Users();
                obj.Id = (int)dt.Rows[i]["Id"];
                obj.Name = (string?)dt.Rows[i]["Name"];
                obj.EmailId = (string?)dt.Rows[i]["EmailId"];
                obj.Mobile = (string?)dt.Rows[i]["Mobile"];
                lstmain.Add(obj);
            }
            return lstmain;
        }
    }
}
