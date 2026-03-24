using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace library
{

    public class CADProduct
    {
        private string constring;

        public CADProduct()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        public bool create(ENProduct en)
        {
            bool success = false;

            SqlConnection c = new SqlConnection(constring);

            try
            {
                c.Open();
                string sql = "INSERT INTO Products (name, code, amount, price, category, creationDate) " +
                             "VALUES (@name, @code, @amount, @price, @category, @creationDate)";

                SqlCommand com = new SqlCommand(sql, c);

                com.Parameters.AddWithValue("@name", en.Name);
                com.Parameters.AddWithValue("@code", en.Code);
                com.Parameters.AddWithValue("@amount", en.Amount);
                com.Parameters.AddWithValue("@price", en.Price);
                com.Parameters.AddWithValue("@category", en.Category);
                com.Parameters.AddWithValue("@creationDate", en.CreationDate);

                com.ExecuteNonQuery();
                success = true; 
            }
            catch (SqlException ex)
            {
                success = false;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
            finally
            {
                c.Close();
            }

            return success;
        }

        public bool update(ENProduct en)
        {
            bool success = false;
            SqlConnection c = new SqlConnection(constring);

            try
            {
                c.Open();
                string sql = "UPDATE Products SET name = @name, amount = @amount, price = @price, " +
                             "category = @category, creationDate = @creationDate WHERE code = @code";

                SqlCommand com = new SqlCommand(sql, c);

                com.Parameters.AddWithValue("@name", en.Name);
                com.Parameters.AddWithValue("@amount", en.Amount);
                com.Parameters.AddWithValue("@price", en.Price);
                com.Parameters.AddWithValue("@category", en.Category);
                com.Parameters.AddWithValue("@creationDate", en.CreationDate);
                com.Parameters.AddWithValue("@code", en.Code);

                if(com.ExecuteNonQuery() > 0)
                {
                    success = true;
                }
            }
            catch (SqlException ex)
            {
                success = false;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
            finally
            {
                c.Close();
            }
            return success;
        }

        public bool delete(ENProduct en)
        {
            bool success = false;
            SqlConnection c = new SqlConnection(constring);

            try
            {
                c.Open();
                // Borramos usando el Code
                string sql = "DELETE FROM Products WHERE code = @code";

                SqlCommand com = new SqlCommand(sql, c);
                com.Parameters.AddWithValue("@code", en.Code);

                if (com.ExecuteNonQuery() > 0)
                {
                    success = true;
                }
            }
            catch (SqlException ex)
            {
                success = false;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
            finally
            {
                c.Close();
            }

            return success;
        }
    }
}
