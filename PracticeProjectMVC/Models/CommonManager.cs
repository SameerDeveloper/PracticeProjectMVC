using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PracticeProjectMVC.Models
{
    public class CommonManager
    {
        public Product DBOperation(int id)
        {
            string _ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(_ConnectionString);
            try //try is for doing operation
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.spProducts";
                SqlParameter param = cmd.Parameters.Add("@ProductID", SqlDbType.Int);
                param.Value = id;
                cmd.CommandTimeout = 0;

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                var raw = dt.Rows[0];

                Product p = new Product();
                p.ProductID = Convert.ToInt32(dt.Rows[0]["ProductID"]);
                p.ProductName = raw["ProductName"].ToString();
                p.SupplierID = Convert.ToInt32(dt.Rows[0]["SupplierID"]);
                p.CategoryID = Convert.ToInt32(dt.Rows[0]["CategoryID"]);
                p.QuantityPerUnit = raw["QuantityPerUnit"].ToString();
                p.UnitPrice = Convert.ToDecimal(dt.Rows[0]["UnitPrice"]);
                p.UnitsInStock = Convert.ToInt32(dt.Rows[0]["UnitsinStock"]);
                p.UnitsOnOrder = Convert.ToInt32(dt.Rows[0]["UnitsOnOrder"]);
                p.ReorderLevel = Convert.ToInt32(dt.Rows[0]["ReorderLevel"]);
                p.Discontinued = Convert.ToInt32(dt.Rows[0]["Discontinued"]);
                return p;
                
            }
            catch (Exception) // catch is for the 
            {
                return null;
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}