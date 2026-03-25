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

        // Método para leer un producto específico por su código
        [cite_start]// Devuelve solo el producto indicado leído de la BD [cite: 459]
        public bool read(ENProduct en)
        {
            bool success = false;
            SqlConnection c = new SqlConnection(constring);

            try
            {
                c.Open();
                string sql = "SELECT * FROM Products WHERE code = @code";
                SqlCommand com = new SqlCommand(sql, c);
                com.Parameters.AddWithValue("@code", en.Code);

                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read()) // Si encuentra el producto...
                {
                    // Rellenamos el objeto con los datos de la BD
                    en.Name = dr["name"].ToString();
                    en.Amount = int.Parse(dr["amount"].ToString());
                    en.Price = float.Parse(dr["price"].ToString());
                    en.Category = int.Parse(dr["category"].ToString());
                    en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                    success = true;
                }
                dr.Close();
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

        // Método para leer el primer producto
        [cite_start]// Devuelve solo el primer producto de la BD [cite: 460]
        public bool readFirst(ENProduct en)
        {
            bool success = false;
            SqlConnection c = new SqlConnection(constring);

            try
            {
                c.Open();
                // Ordenamos por código de forma ascendente y cogemos el primero (TOP 1)
                string sql = "SELECT TOP 1 * FROM Products ORDER BY code ASC";
                SqlCommand com = new SqlCommand(sql, c);

                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    en.Code = dr["code"].ToString();
                    en.Name = dr["name"].ToString();
                    en.Amount = int.Parse(dr["amount"].ToString());
                    en.Price = float.Parse(dr["price"].ToString());
                    en.Category = int.Parse(dr["category"].ToString());
                    en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                    success = true;
                }
                dr.Close();
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

        // Método para leer el siguiente producto al indicado
        [cite_start]// Devuelve solo el producto siguiente al indicado [cite: 461]
        public bool readNext(ENProduct en)
        {
            bool success = false;
            SqlConnection c = new SqlConnection(constring);

            try
            {
                c.Open();
                // Buscamos el primer producto cuyo código sea mayor al actual, en orden alfabético
                string sql = "SELECT TOP 1 * FROM Products WHERE code > @code ORDER BY code ASC";
                SqlCommand com = new SqlCommand(sql, c);
                com.Parameters.AddWithValue("@code", en.Code);

                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    en.Code = dr["code"].ToString();
                    en.Name = dr["name"].ToString();
                    en.Amount = int.Parse(dr["amount"].ToString());
                    en.Price = float.Parse(dr["price"].ToString());
                    en.Category = int.Parse(dr["category"].ToString());
                    en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                    success = true;
                }
                dr.Close();
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

        // Método para leer el producto anterior al indicado
        [cite_start]// Devuelve solo el producto anterior al indicado [cite: 462]
        public bool readPrev(ENProduct en)
        {
            bool success = false;
            SqlConnection c = new SqlConnection(constring);

            try
            {
                c.Open();
                // Buscamos el primer producto cuyo código sea menor al actual, ordenado de forma descendente
                string sql = "SELECT TOP 1 * FROM Products WHERE code < @code ORDER BY code DESC";
                SqlCommand com = new SqlCommand(sql, c);
                com.Parameters.AddWithValue("@code", en.Code);

                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    en.Code = dr["code"].ToString();
                    en.Name = dr["name"].ToString();
                    en.Amount = int.Parse(dr["amount"].ToString());
                    en.Price = float.Parse(dr["price"].ToString());
                    en.Category = int.Parse(dr["category"].ToString());
                    en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                    success = true;
                }
                dr.Close();
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
