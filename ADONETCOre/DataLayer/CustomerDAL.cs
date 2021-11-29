using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ADONETCOre.Models;
using System.Data;

namespace ADONETCOre.DataLayer
{
    public class CustomerDAL
    {
        public string cnn = "";

        public CustomerDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).
                AddJsonFile("appSettings.json").Build();

            cnn = builder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }

        public List<Customers> GetAllCustomers()
        {
            List<Customers> ListOfCustomers = new List<Customers>();
            using(SqlConnection cn=new SqlConnection(cnn))
            {
                using(SqlCommand cmd=new SqlCommand("GetAllCustomers", cn))
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListOfCustomers.Add(new Customers()
                        {
                            CustomerId=int.Parse(reader["CustomerId"].ToString()),
                            Customername=reader["Customername"].ToString(),
                            EmailAddress = reader["EmailAddress"].ToString(),
                            Mobile = reader["Mobile"].ToString(),

                        });
                    }
                }
            }
            return ListOfCustomers;
        }

        public List<Customers> GetCustomerById(int CustomerId)
        {
            List<Customers> ListOfCustomers = new List<Customers>();
            using (SqlConnection cn = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("GetCustomerDetailsById", cn))
                {
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int);
                    cmd.Parameters["@CustomerId"].Value = CustomerId;
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (cn.State == ConnectionState.Closed)
                        cn.Open();

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListOfCustomers.Add(new Customers()
                        {
                            CustomerId = int.Parse(reader["CustomerId"].ToString()),
                            Customername = reader["Customername"].ToString(),
                            EmailAddress = reader["EmailAddress"].ToString(),
                            Mobile = reader["Mobile"].ToString(),

                        });
                    }
                }
            }
            return ListOfCustomers;
        }
    }
}
