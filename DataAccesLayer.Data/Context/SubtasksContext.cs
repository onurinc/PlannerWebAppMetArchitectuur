using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DataAccesLayer.Data.Data_Transfer_Object;
using DataAccesLayer.Data.InterfaceContext;

namespace DataAccesLayer.Data.Context
{
    public class SubtasksContext : ISubtasksContext
    {
        // Connectionstring for my desktop
        public string connectionstring = "Server=localhost\\SQLEXPRESS;Database=PlannerWebApp;Trusted_Connection=True;";

        // Connectionstring for my laptop
        // public string connectionstring = "Data Source=DESKTOP-NCSPB7A;Initial Catalog=PlannerWebApp;Integrated Security=True";

        public IEnumerable<SubtasksDTO> GetAllSubtasks()
        {
            var NotesList = new List<SubtasksDTO>();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sqlQuery =
                    "SELECT * FROM Subtasks";

                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var subtask = new SubtasksDTO();
                    subtask.SubtaskId = Convert.ToInt32(dr["SubtaskId"].ToString());
                    subtask.ProjectId = Convert.ToInt32(dr["ProjectId"].ToString());
                    subtask.SubtaskName = dr["SubtaskStatus"].ToString();
                    subtask.SubtaskName = dr["SubtaskName"].ToString();
                    subtask.SubtaskDescription = dr["SubtaskDescription"].ToString();
                    subtask.SubtaskLabel = dr["SubtaskLabel"].ToString();
                    NotesList.Add(subtask);
                }
                conn.Close();
            }
            return (NotesList);
        }

        public void AddSubtask(SubtasksDTO subtask)
        {
            string sqlQuery = "INSERT INTO Subtasks(ProjectId, SubtaskStatus, SubtaskName, SubtaskDescription, SubtaskLabel) VALUES(@ProjectId, @SubtaskStatus, @SubtaskName, @SubtaskDescription, @SubtaskLabel)";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@ProjectId", subtask.ProjectId);
                command.Parameters.AddWithValue("@SubtaskStatus", subtask.SubtaskStatus);
                command.Parameters.AddWithValue("@SubtaskName", subtask.SubtaskName);
                command.Parameters.AddWithValue("@SubtaskDescription", subtask.SubtaskDescription);
                command.Parameters.AddWithValue("@SubtaskLabel", subtask.SubtaskLabel);
                command.ExecuteNonQuery();
            }
        }

        public SubtasksDTO GetSubtask(int id)
        {
            string sqlQuery = "SELECT * FROM Subtasks WHERE SubtaskId = @SubtaskId";
            using (var conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@SubtaskId", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var subtask = new SubtasksDTO();
                        {
                            subtask.SubtaskId = (int)reader["SubtaskId"];
                            subtask.ProjectId = (int)reader["ProjectId"];
                            subtask.SubtaskStatus = (bool)reader["SubtaskStatus"];
                            subtask.SubtaskName = reader["SubtaskName"]?.ToString();
                            subtask.SubtaskDescription = reader["SubtaskDescription"]?.ToString();
                            subtask.SubtaskLabel = reader["SubtaskLabel"]?.ToString();
                        };
                        return subtask;
                    }
                }
                return null;
            }
        }

        public void EditSubtask(SubtasksDTO subtask)
        {
            string sqlQuery = "UPDATE Subtasks SET ProjectId = @ProjectId, SubtaskStatus = @SubtaskStatus, SubtaskName = @SubtaskName, SubtaskDescription = @SubtaskDescription, SubtaskLabel = @SubtaskLabel WHERE SubtaskId = @SubtaskId;";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@SubtaskId", subtask.SubtaskId);
                command.Parameters.AddWithValue("@ProjectId", subtask.ProjectId);
                command.Parameters.AddWithValue("@SubtaskStatus", subtask.SubtaskStatus);
                command.Parameters.AddWithValue("@SubtaskName", subtask.SubtaskName);
                command.Parameters.AddWithValue("@SubtaskDescription", subtask.SubtaskDescription);
                command.Parameters.AddWithValue("@SubtaskLabel", subtask.SubtaskLabel);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteSubtask(int id)
        {
            string sqlQuery = "DELETE FROM Subtasks WHERE SubtaskId = @SubtaskId";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlQuery, conn);
                command.Parameters.AddWithValue("@SubtaskId", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
