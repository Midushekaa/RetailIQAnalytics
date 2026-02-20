using System;
using System.Data;
using System.Data.SqlClient;
using RetailIQAnalytics.DataLayer;

namespace RetailIQAnalytics.ServiceLayer
{
    public class UserService
    {
        private DatabaseHelper db = new DatabaseHelper();

        // REGISTER
        public bool Register(string username, string password, string fullName)
        {
            string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username=@username";

            SqlParameter[] checkParams =
            {
                new SqlParameter("@username", username)
            };

            int count = Convert.ToInt32(db.ExecuteScalar(checkQuery, checkParams));

            if (count > 0)
                return false; // Username already exists

            string passwordHash = db.HashPassword(password);

            string insertQuery = @"INSERT INTO Users 
                                   (Username, PasswordHash, FullName, Role, IsActive)
                                   VALUES (@username, @password, @fullName, 'Executive', 1)";

            SqlParameter[] insertParams =
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", passwordHash),
                new SqlParameter("@fullName", fullName)
            };

            int rows = db.ExecuteNonQuery(insertQuery, insertParams);
            return rows > 0;
        }

        // LOGIN
        public bool Login(string username, string password, out string role)
        {
            role = "";

            string passwordHash = db.HashPassword(password);

            string query = @"SELECT Role 
                             FROM Users 
                             WHERE Username=@username 
                             AND PasswordHash=@password
                             AND IsActive = 1";

            SqlParameter[] parameters =
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", passwordHash)
            };

            DataTable dt = db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 1)
            {
                role = dt.Rows[0]["Role"].ToString();
                return true;
            }

            return false;
        }
    }
}
