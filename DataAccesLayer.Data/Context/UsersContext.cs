using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceContext;

namespace DataAccesLayer.Data.Context
{
    public class UsersContext : IUsersContext
    {
        // Connectionstring for my desktop
        private string connectionstring = "Server=localhost\\SQLEXPRESS;Database=PlannerWebApp;Trusted_Connection=True;";

        // Connectionstring for my laptop
        // public string connectionstring = "Data Source=DESKTOP-NCSPB7A;Initial Catalog=PlannerWebApp;Integrated Security=True";

        public IEnumerable<UsersDTO> GetAllUsers()
        {
            var UsersList = new List<UsersDTO>();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sqlQuery =
                    "SELECT * FROM UserCredentials";

                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var user = new UsersDTO();
                    user.UserId = Convert.ToInt32(dr["UserId"].ToString());
                    user.Username = (dr["Username"].ToString());
                    UsersList.Add(user);
                }
                conn.Close();
            }
            return UsersList;
        }

        public UsersDTO GetUser(int id)
        {
            string sqlQuery = "SELECT * FROM UserCredentials WHERE UserId = @UserId";
            using (var conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@UserId", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new UsersDTO();
                        {
                            user.UserId = (int)reader["UserId"];
                            user.Username = reader["Username"].ToString();

                        };
                        return user;
                    }
                }
                return null;
            }
        }
    }
}
