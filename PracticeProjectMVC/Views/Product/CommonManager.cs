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
                //SqlParameter param = cmd.Parameters.Add("@ProductID", SqlDbType.Int);
                //param.Value = id;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ProductID";
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
        public Product GetDBProduct(int productid)
        {
            string _ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(_ConnectionString);

            try //for the operation
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.spProducts";
                SqlParameter parame = new SqlParameter();
                parame.ParameterName = "@Type";
                parame.Value = 1;
                parame.ParameterName = "@ProductID";
                parame.Value = productid;
                cmd.Parameters.Add(parame); 

                DataTable ddt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ddt);

                var raw = ddt.Rows[0];

                Product prod = new Product();

                prod.ProductID = Convert.ToInt32(ddt.Rows[0]["ProductID"]);
                prod.ProductName = raw["ProductName"].ToString();
                prod.SupplierID = Convert.ToInt32(ddt.Rows[0]["SupplierID"]);
                prod.CategoryID = Convert.ToInt32(ddt.Rows[0]["CategoryID"]);
                prod.QuantityPerUnit = raw["QuantityPerUnit"].ToString();
                prod.UnitPrice = Convert.ToDecimal(ddt.Rows[0]["UnitPrice"]);
                prod.UnitsInStock = Convert.ToInt32(ddt.Rows[0]["UnitsInStock"]);
                prod.UnitsOnOrder = Convert.ToInt32(ddt.Rows[0]["UnitsOnOrder"]);
                prod.ReorderLevel = Convert.ToInt32(ddt.Rows[0]["ReorderLevel"]);
                prod.Discontinued = Convert.ToInt32(ddt.Rows[0]["Discontinued"]);
                return prod;
            }
            catch (Exception)
            {

                return null;
                throw;


            }
            finally
            {
                sqlConnection.Close();
            }
        }
            public List<Product> GetAllStudent()
        {
            string _ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(_ConnectionString);

            try  
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.spProducts";
                SqlParameter parame = new SqlParameter();
                parame.ParameterName = "@Type";
                parame.Value = 2;
                cmd.Parameters.Add(parame); 
                List<Product> list = new List<Product>();
                DataTable dtt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtt);

                for (int i = 0; i < dtt.Rows.Count; i++)
                {
                    var raw = dtt.Rows[i];
                    Product prot = new Product();
                    prot.ProductID = Convert.ToInt32(dtt.Rows[i]["ProductID"]);
                    prot.ProductName = raw["ProductName"].ToString();
                    prot.SupplierID = Convert.ToInt32(dtt.Rows[i]["SupplierID"]);
                    prot.CategoryID = Convert.ToInt32(dtt.Rows[i]["CategoryID"]);
                    prot.QuantityPerUnit = raw["QuantityPerUnit"].ToString();
                    prot.UnitPrice = Convert.ToDecimal(dtt.Rows[i]["UnitPrice"]);
                    prot.UnitsInStock = Convert.ToInt32(dtt.Rows[i]["UnitsInStock"]);
                    prot.UnitsOnOrder = Convert.ToInt32(dtt.Rows[i]["UnitsOnOrder"]);
                    prot.ReorderLevel = Convert.ToInt32(dtt.Rows[i]["ReorderLevel"]);
                    prot.Discontinued = Convert.ToInt32(dtt.Rows[i]["Discontinued"]);
                    list.Add(prot);
                }
                return list;
            }
            catch (Exception)
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

