using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    public class CADCategory
    {
        private string constring;

        public CADCategory()
        {
            constring = ConfigurationManager.ConnectionStrings["ConexionBD"].ToString();
        }

        // Método para leer una categoría concreta por su ID
        public bool read(ENCategory en)
        {
            bool success = false;
            SqlConnection c = new SqlConnection(constring);

            try
            {
                c.Open();
                string sql = "SELECT * FROM Categories WHERE id = @id";
                SqlCommand com = new SqlCommand(sql, c);
                com.Parameters.AddWithValue("@id", en.Id);

                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    en.Id = int.Parse(dr["id"].ToString());
                    en.Name = dr["name"].ToString();
                    success = true;
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                success = false;
                Console.WriteLine("Category operation has failed. Error: {0}", ex.Message);
            }
            finally
            {
                c.Close();
            }

            return success;
        }

        public List<ENCategory> readAll()
        {
            List<ENCategory> lista = new List<ENCategory>();
            SqlConnection c = new SqlConnection(constring);

            try
            {
                c.Open();
                string sql = "SELECT * FROM Categories";
                SqlCommand com = new SqlCommand(sql, c);

                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read()) 
                {
                    ENCategory cat = new ENCategory();
                    cat.Id = int.Parse(dr["id"].ToString());
                    cat.Name = dr["name"].ToString();
                    lista.Add(cat); 
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Category operation has failed. Error: {0}", ex.Message);
            }
            finally
            {
                c.Close();
            }

            return lista;
        }
    }
}
