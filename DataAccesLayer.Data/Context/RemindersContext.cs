using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceContext;

namespace DataAccesLayer.Data.Context
{
    public class RemindersContext : IRemindersContext
    {
        // Connectionstring for my desktop
        public string connectionstring = "Server=localhost\\SQLEXPRESS;Database=PlannerWebApp;Trusted_Connection=True;";

        // Connectionstring for my laptop
        public string connectionstring = "Data Source=DESKTOP-NCSPB7A;Initial Catalog=PlannerWebApp;Integrated Security=True";


        public IEnumerable<RemindersDTO> GetAllReminders()
        {
            var ReminderList = new List<RemindersDTO>();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sqlQuery =
                    "SELECT * FROM Reminders";

                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var reminder = new RemindersDTO();
                    reminder.ReminderId = Convert.ToInt32(dr["ReminderId"].ToString());
                    reminder.UserId = Convert.ToInt32(dr["UserId"].ToString());
                    reminder.ReminderName = dr["ReminderName"].ToString();
                    reminder.ReminderDescription = dr["ReminderDescription"].ToString();
                    ReminderList.Add(reminder);
                }
                conn.Close();
            }
            return ReminderList;
        }

        public void AddReminder(RemindersDTO reminder)
        {
            string sqlQuery = "INSERT INTO Reminders(UserId, ReminderName, ReminderDescription) VALUES(@UserId, @ReminderName, @ReminderDescription)";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@UserId", reminder.UserId);
                command.Parameters.AddWithValue("@ReminderName", reminder.ReminderName);
                command.Parameters.AddWithValue("@ReminderDescription", reminder.ReminderDescription);
                command.ExecuteNonQuery();
            }
        }

        public RemindersDTO GetReminder(int id)
        {
            string sqlQuery = "SELECT * FROM Reminders WHERE ReminderId = @ReminderId";
            using (var conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@ReminderId", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var reminder = new RemindersDTO();
                        {
                            reminder.ReminderId = (int)reader["ReminderId"];
                            reminder.UserId = (int)reader["UserId"];
                            reminder.ReminderName = reader["ReminderName"]?.ToString();
                            reminder.ReminderDescription = reader["ReminderDescription"]?.ToString();
                        };
                        return reminder;
                    }
                }
                return null;
            }
        }

        public void EditReminder(RemindersDTO reminder)
        {
            string sqlQuery = "UPDATE Reminders SET UserId = @UserId, ReminderName = @ReminderName, ReminderDescription = @ReminderDescription WHERE ReminderId = @ReminderId;";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@ReminderId", reminder.ReminderId);
                command.Parameters.AddWithValue("@UserId", reminder.UserId);
                command.Parameters.AddWithValue("@ReminderName", reminder.ReminderName);
                command.Parameters.AddWithValue("@ReminderDescription", reminder.ReminderDescription);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteReminder(int id)
        {
            string sqlQuery = "DELETE FROM Reminders WHERE ReminderId = @ReminderId";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@ReminderId", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
