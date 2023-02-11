using System.Collections.Generic;
using System.Data.SqlClient;

namespace ApiCrudUsingGeneric.DAL
{

    //public sealed class AdoRepository
    //{
    //    private IConfiguration Configuration;
    //    string connString = null;
    //    private static SqlConnection _connection1;
    //    public AdoRepository(IConfiguration _configuration)
    //    {
    //        Configuration = _configuration;
    //        connString = this.Configuration.GetConnectionString("DefaultConnection");
    //        try
    //        {
    //            if (connString != null)
    //            {
    //                _connection1 = new SqlConnection(connString);
    //            }
    //            else
    //            {
    //                _connection1 = null;
    //            }
    //        }
    //        catch (SqlException e)
    //        {
    //            throw e;
    //        }
    //    }



    //}

    public abstract class AdoRepository<T> where T : class
    {
        private static SqlConnection _connection;
        public AdoRepository(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }
        public virtual T PopulateRecord(SqlDataReader reader)
        {
            return null;
        }

        protected IEnumerable<T> GetRecords(SqlCommand command)
        {
            var list = new List<T>();
            command.Connection = _connection;
            _connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        list.Add(PopulateRecord(reader));
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            finally { _connection.Close(); }
            return list;
        }


        protected T GetRecord(SqlCommand command)
        {
            T record = null;
            command.Connection = _connection;
            _connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        record = PopulateRecord(reader);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            finally { _connection.Close(); }
            return record;
        }
    }
}
