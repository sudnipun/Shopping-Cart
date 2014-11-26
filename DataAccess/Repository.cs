using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoppingCart.DataAccess
{
    public static class Repository
    {
        private static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        private static SqlDataReader _reader;
        public static void InsertUser(string firstName, string lastName, string email) 
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            string sql = "insert into [Users] (FirstName, LastName, EmailAddress) values(@firstName, @lastName, @email)";
            using (SqlCommand insertuser = new SqlCommand(sql, conn))
            {
                insertuser.Parameters.AddWithValue("@firstName", firstName);
                insertuser.Parameters.AddWithValue("@lastName", lastName);
                insertuser.Parameters.AddWithValue("@email", email);

            }
        }

        public static int GetUser(string email) 
        {
            string sql = "select EmailAddress from [Users] where EmailAddress=" + "'"+email+"'";
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            _reader = SqlQueryRunner(sql, conn);
            if (_reader.HasRows) {
                return 1;
            }
            else
            {
                return 0;
            }
            
        }

        public static SqlDataReader SqlQueryRunner(string query, SqlConnection conn)
        {
            try
            {
                using (var command = new SqlCommand(query, conn) { CommandType = System.Data.CommandType.Text })
                {
                    conn.Open();
                    _reader = command.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return _reader;
        }


        public static List<ProductEntryModel> GetProductList()
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            
            SqlDataReader _reader;
            string query = "Select * from Products";
            
            List<ProductEntryModel> productList = new List<ProductEntryModel>();


            _reader = SqlQueryRunner(query, conn);
                    if (_reader.HasRows)
                    {
                        while (_reader.Read())
                        {
                            ProductEntryModel productEntry = new ProductEntryModel();
                            productEntry.Name = _reader.GetString(_reader.GetOrdinal("ProductName"));
                            productEntry.Description = _reader.GetString(_reader.GetOrdinal("Description"));
                            productEntry.Price = _reader.GetDecimal(_reader.GetOrdinal("Price"));
                            productList.Add(productEntry);
                        }
                    }
                    
               
                
            
            return productList;
           
        }

        public static List<OrderEntryModel> GetallOrders() 
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            List<OrderEntryModel> orderList = new List<OrderEntryModel>();
            SqlDataReader _reader;
            string query = "Select u.FirstName, u.LastName, u.EmailAddress, p.ProductName, p.Price, o.DatePurchased from Products p, Users u , Orders o Where p.Id = o.ProductID AND u.ID = o.UserId";
            _reader = SqlQueryRunner(query, conn);
            if (_reader.HasRows)
            {
                while (_reader.Read())
                {
                    OrderEntryModel orderEntry = new OrderEntryModel();
                    orderEntry.FirstName = _reader.GetString(_reader.GetOrdinal("FirstName"));
                    orderEntry.LastName = _reader.GetString(_reader.GetOrdinal("LastName"));
                    orderEntry.EmailAddress = _reader.GetString(_reader.GetOrdinal("EmailAddress"));
                    orderEntry.ProductName = _reader.GetString(_reader.GetOrdinal("ProductName"));
                    orderEntry.ProductPrice = _reader.GetDecimal(_reader.GetOrdinal("Price"));
                    orderEntry.PurchaseDate = _reader.GetDateTime(_reader.GetOrdinal("DatePurchased"));
                    orderList.Add(orderEntry);
                }
            }
            return orderList;
        }
    }
}