using System.Data;
using System.Data.SqlClient;
using ClassLibraryModel;
using System.Data.SqlClient;
using System.Data;
using System.Net.NetworkInformation;
using ClassLibrary;


namespace ClassLibrary

{
    public class DalUsers{ 
        public static void InsertUser(User user)
        {
            SqlConnection con = DbHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            cmd.Parameters.AddWithValue("@UserEmail", user.UserEmail);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static List<User> GetAllUsers()
        {
            SqlConnection con = DbHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("GetAllUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> userList = new List<User>();

            while (reader.Read())
            {
                User user = new User();
                user.Id = Convert.ToInt32(reader["Id"]);
                user.Username = reader["Username"].ToString();
                user.PasswordHash = reader["PasswordHash"].ToString();
                user.UserEmail = reader["UserEmail"].ToString();
                userList.Add(user);
            }

            con.Close();
            return userList;
        }

        public static User FindUserByEmaill(string email)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("FindUserByEmail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserEmail", email);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    User user = new User();
                    user.Id = Convert.ToInt32(reader["Id"]);
                    user.Username = reader["Username"].ToString();
                    user.PasswordHash = reader["PasswordHash"].ToString();
                    user.UserEmail = reader["UserEmail"].ToString();

                    con.Close();
                    return user;
                }

                con.Close();
                return null;
            }
        }

        public static void UpdateUser(User user)
        {
            SqlConnection con = DbHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", user.Id);
            cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            cmd.Parameters.AddWithValue("@UserEmail", user.UserEmail);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void DeleteUserById(int userId)
        {
            SqlConnection con = DbHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteUserById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void DeleteUserByUsername(string username)
        {
            SqlConnection con = DbHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteUserByUsername", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
