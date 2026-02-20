using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace RetailIQAnalytics.DataLayer
{
    public class DatabaseHelper
    {
        private string connStr = @"Data Source=DESKTOP-8219B0E\SQLEXPRESS01;
                           Initial Catalog=RetailIQAnalytics;
                           Integrated Security=True;
                           Encrypt=True;
                           TrustServerCertificate=True;";


        // Execute a query and return a DataTable
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Execute INSERT/UPDATE/DELETE
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // Execute a scalar query (e.g., COUNT(*))
        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        // Execute a stored procedure and return DataTable
        public DataTable ExecuteProcedure(string procedureName, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        // Hash a password using SHA256
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }
    }
}
